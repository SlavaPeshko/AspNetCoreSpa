using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Models.Likes;
using AspNetCoreSpa.Application.Models.Posts;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Domain.Entities.Enum;
using AspNetCoreSpa.Infrastructure.Options;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;
using Transaction = AspNetCoreSpa.Application.Helpers.Transaction;

namespace AspNetCoreSpa.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IFileService _fileService;
        private readonly GlobalSettings _globalSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILikeQueryRepository _likeQueryRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        private readonly IPostQueryRepository _postQueryRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUserContext _userContext;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository,
            IPostQueryRepository postQueryRepository,
            IUnitOfWorks unitOfWorks,
            IMapper mapper,
            IUserContext userContext,
            IUserRepository userRepository,
            IFileService fileService,
            IHttpContextAccessor httpContextAccessor,
            ILikeRepository likeRepository,
            ILikeQueryRepository likeQueryRepository,
            GlobalSettings globalSettings,
            IUserQueryRepository userQueryRepository)
        {
            _postRepository = postRepository;
            _postQueryRepository = postQueryRepository;
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _userContext = userContext;
            _userRepository = userRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
            _likeRepository = likeRepository;
            _likeQueryRepository = likeQueryRepository;
            _globalSettings = globalSettings;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<Result<PostViewModel>> CreatePostAsync(CreatePostModel model)
        {
            if (_userContext.UserId == -1)
                return Result.Fail<PostViewModel>(EC.UserNotFound, ET.UserNotFound);

            var user = await _userRepository.GetUserByIdAsync(_userContext.UserId);
            if (user == null)
                return Result.Fail<PostViewModel>(EC.UserNotFound, ET.UserNotFound);

            var post = model.ToEntity();

            post.CreateAt = DateTime.UtcNow;
            post.User = user;

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            using (var transaction = Transaction.CreateAsyncTransactionScope())
            {
                await _postRepository.PostAsync(post);

                await _unitOfWorks.CommitAsync();

                await _fileService.UploadImagesAsync(post.Id, model.Images);

                transaction.Complete();
            }

            return Result.OK(post.ToViewModel());
        }

        public async Task<Result> DeletePostByIdAsync(int id)
        {
            var post = _userContext.IsInRole(UserRoleEnum.Admin)
                ? await _postRepository.GetPostByIdAsync(id)
                : await _postRepository.GetPostByIdAndUserIdAsync(id, _userContext.UserId);

            if (post == null)
                return Result.Fail<PostViewModel>(EC.PostNotFound, ET.PostNotFound);

            _postRepository.Delete(post);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<Result<PostViewModel>> GetPostByIdAsync(int id)
        {
            var post = await _postQueryRepository.GetPostByIdAsync(id);
            if (post == null)
                return Result.Fail<PostViewModel>(EC.PostNotFound, ET.PostNotFound);

            var vm = _mapper.Map<PostDto, PostViewModel>(post);

            return Result.OK(vm);
        }

        public async Task<IEnumerable<PostViewModel>> GetPostsAsync(PostPageFilters filters)
        {
            var posts = await _postQueryRepository.GetPagePostsAsync(new PostPageFiltersDto
            {
                PageNumber = filters.PageNumber,
                ItemsPerPage = filters.ItemsPerPage
            });

            var viewModels = posts.Select(x => x.ToViewModel()).ToList();

            var url = new StringBuilder();
            url.Append(_httpContextAccessor.HttpContext?.Request?.Scheme);
            url.Append("://");
            url.Append(_httpContextAccessor.HttpContext?.Request?.Host.Value);
            url.Append("/");

            foreach (var post in viewModels)
            {
                SetImagesUrl(post.Images, url);
                post.CountLike = post.Likes.Count(x => x.IsLike) - post.Likes.Count(x => !x.IsLike);

                if (post.User.Image != null)
                {
                    post.User.Image.Url = $"{url}{post.User.Image.Path.Replace(@"\", "/")}";
                    continue;
                }

                post.User.Image ??= new ImageViewModel
                {
                    Url = $"{url}{_globalSettings.Paths.DefaultPhotoProfilePath.Replace(@"\", "/")}",
                    Name = _globalSettings.Paths.DefaultPhotoName
                };

                post.Likes = post.Likes.Where(x => x.UserId == _userContext.UserId).ToList();
            }

            return viewModels;
        }

        public async Task<Result> UpdatePostAsync(int id, UpdatePostModel model)
        {
            if (_userContext.UserId == -1)
                return Result.Fail(EC.UserNotFound, ET.UserNotFound);

            var entity = await _postRepository.GetPostByIdAndUserIdAsync(id, _userContext.UserId);
            if (entity == null)
                return Result.Fail(EC.PostNotFound, ET.PostNotFound);

            entity.Description = model.Description;
            entity.UpdateAt = DateTime.UtcNow;

            _postRepository.Put(entity);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<Result<PostViewModel>> CreateLikePostAsync(int postId, bool isLike)
        {
            if (_userContext.UserId == -1)
                return Result.Fail<PostViewModel>(EC.UserNotFound, ET.UserNotFound);

            var user = await _userRepository.GetUserByIdAsync(_userContext.UserId);
            if (user == null)
                return Result.Fail<PostViewModel>(EC.UserNotFound, ET.UserNotFound);

            var post = await _postRepository.GetPostByIdAsync(postId);
            if (post == null)
                return Result.Fail<PostViewModel>(EC.PostNotFound, ET.PostNotFound);

            var like = new Like
            {
                Post = post,
                User = user,
                IsLike = isLike
            };

            await _likeRepository.PostAsync(like);
            await _unitOfWorks.CommitAsync();

            var countLike = await _likeQueryRepository.GetRatingByPostIdAsync(postId);
            var model = new PostViewModel
            {
                CountLike = countLike,
                Likes = new List<LikeViewModel>
                {
                    new LikeViewModel
                    {
                        Id = like.Id,
                        IsLike = like.IsLike,
                        PostId = like.Post.Id,
                        UserId = like.User.Id
                    }
                }
            };

            return Result.OK(model);
        }

        public async Task<Result<IEnumerable<LikeViewModel>>> GetLikesByPostIdAsync(int postId)
        {
            if (_userContext.UserId == -1 || !await _userQueryRepository.IsExistUserAsync(_userContext.UserId))
                return Result.Fail<IEnumerable<LikeViewModel>>(EC.UserNotFound, ET.UserNotFound);

            var likes = await _likeQueryRepository.GetLikesByPostIdAsync(postId, _userContext.UserId);

            return Result.OK(likes.Select(x => x.ToViewModel()));
        }

        private static void SetImagesUrl(IEnumerable<ImageViewModel> images, StringBuilder url)
        {
            foreach (var image in images) image.Url = $"{url}{image.Path.Replace(@"\", "/")}";
        }
    }
}