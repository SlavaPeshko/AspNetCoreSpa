using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public PostService(IPostRepository postRepository,
            IPostQueryRepository postQueryRepository,
            IUnitOfWorks unitOfWorks,
            IMapper mapper,
            IUserContext userContext,
            IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _postQueryRepository = postQueryRepository;
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _userContext = userContext;
            _userRepository = userRepository;
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
            await _unitOfWorks.CommitAsync();

            return Result.OK(entity.ToViewModel());
        }

        public async Task<Result> DeletePostByIdAsync(Guid id)
        {
            var post = _userContext.IsInRole(RoleEnum.Admin)
                ? await _postRepository.GetPostByIdAsync(id)
                : await _postRepository.GetPostByIdAndUserIdAsync(id, _userContext.UserId);
            
            if (post == null)
                return Result.Fail<PostViewModel>(EC.PostNotFound, ET.PostNotFound);

            _postRepository.Delete(post);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<Result<PostViewModel>> GetPostByIdAsync(Guid id)
        {
            var post = await _postQueryRepository.GetPostByIdAsync(id);
            // var post = await _postRepository.GetPostByIdAsync(id);

            if(post == null)
            {
                return Result.Fail<PostViewModel>(EC.PostNotFound, ET.PostNotFound);
            }

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

            return posts.Select(x => x.ToViewModel());
        }

        public Task<Result> UpdatePostAsync(Guid id, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
