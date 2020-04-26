using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Application.Models.Post;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Domain.Entities.Enum;
using Microsoft.AspNetCore.Http;
using PostPageFilters = AspNetCoreSpa.Application.Models.Post.PostPageFilters;

namespace AspNetCoreSpa.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostQueryRepository _postQueryRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILikeRepository _likeRepository;
        private readonly ILikeQueryRepository _likeQueryRepository;

        public PostService(IPostRepository postRepository,
            IPostQueryRepository postQueryRepository,
            IUnitOfWorks unitOfWorks,
            IMapper mapper,
            IUserContext userContext,
            IUserRepository userRepository, 
            IFileService fileService, 
            IHttpContextAccessor httpContextAccessor, 
            ILikeRepository likeRepository, 
            ILikeQueryRepository likeQueryRepository)
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
        }

        public async Task<Result<PostViewModel>> CreatePostAsync(CreatePostInputModel post)
        {
            var user = await _userRepository.GetUserByIdAsync(_userContext.UserId);
            if(user == null)
                return Result.Fail<PostViewModel>(EC.UserNotFound, ET.UserNotFound);
            
            var entity = post.ToEntity();

            entity.CreateAt = DateTime.UtcNow;
            entity.User = user;

            await _postRepository.PostAsync(entity);
            
            await _fileService.UploadImagesAsync(user.Id, entity.Id, post.Images);
            
            await _unitOfWorks.CommitAsync();

            return Result.OK(entity.ToViewModel());
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
            if(post == null)
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
                post.CountLike = post.Likes.Count(x => x.IsLike) - post.Likes.Count(x => !x.IsLike); 
                post.User.Image.Url = $"{url}{post.User.Image.Path.Replace(@"\", "/")}";
                
                SetImagesUrl(post.Images, url);
            }
            
            return viewModels;
        }

        public async Task<Result> UpdatePostAsync(int id, UpdatePostInputModel model)
        {
            var entity = await _postRepository.GetPostByIdAndUserIdAsync(id, _userContext.UserId);
            if(entity == null)
                return Result.Fail(EC.PostNotFound, ET.PostNotFound);

            entity.Description = model.Description;
            entity.UpdateAt = DateTime.UtcNow;

            _postRepository.Put(entity);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<Result<int>> CreatLikePostAsync(int postId, bool isLike)
        {
            var user = await _userRepository.GetUserByIdAsync(_userContext.UserId);
            if(user == null)
                return Result.Fail<int>(EC.UserNotFound, ET.UserNotFound);

            var post = await _postRepository.GetPostByIdAsync(postId);
            if (post == null)
                return Result.Fail<int>(EC.PostNotFound, ET.PostNotFound);

            var like = new Like
            {
                Post = post,
                User = user,
                IsLike = isLike
            };

            await _likeRepository.PostAsync(like);
            await _unitOfWorks.CommitAsync();

            var count = await _likeQueryRepository.GetCountLikePostAsync(postId);
            
            return Result.OK(count);
        }

        public async Task<Result<int>> DeleteLikePostAsync(int postId, int likeId)
        {
            var user = await _userRepository.GetUserByIdAsync(_userContext.UserId);
            if(user == null)
                return Result.Fail<int>(EC.UserNotFound, ET.UserNotFound);

            var post = await _postRepository.GetPostByIdAsync(postId);
            if (post == null)
                return Result.Fail<int>(EC.PostNotFound, ET.PostNotFound);

            var like = await _likeRepository.GetLikeByIdAsync(likeId);
            if(like == null)
                return Result.Fail<int>(EC.LikeNotFound, ET.LikeNotFound);
            
            _likeRepository.Delete(like);
            await _unitOfWorks.CommitAsync();

            var count = await _likeQueryRepository.GetCountLikePostAsync(postId);
            
            return Result.OK<int>(count);
        }

        private static void SetImagesUrl(IEnumerable<ImageViewModel> images, StringBuilder url)
        {
            foreach (var image in images)
            {
                image.Url = $"{url}{image.Path.Replace(@"\", "/")}";
            }
        }
    }
}
