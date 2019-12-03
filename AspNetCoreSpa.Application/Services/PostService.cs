using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Enities;
using AspNetCoreSpa.Domain.Enities.Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using EC = AspNetCoreSpa.Domain.Enities.ErrorCode;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Application.Models.Post;
using AspNetCoreSpa.Application.Services.Contracts;

namespace AspNetCoreSpa.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository,
            IUnitOfWorks unitOfWorks,
            IMapper mapper)
        {
            _postRepository = postRepository;
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }

        public async Task<Result<PostViewModel>> CreatePostAsync(CreatePostInputModel post)
        {
            var entity = post.ToEntity();

            entity.CreateAt = DateTime.UtcNow;

            await _postRepository.PostAsync(entity);

            return Result.OK(entity.ToViewModel());
        }

        public async Task<Result> DeletePostByIdAsync(Guid id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);

            if (post == null)
            {
                return Result.Fail<PostViewModel>(EC.PostNotFound, ET.PostNotFound);
            }

            _postRepository.Delete(post);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<Result<PostViewModel>> GetPostByIdAsync(Guid id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);

            if(post == null)
            {
                return Result.Fail<PostViewModel>(EC.PostNotFound, ET.PostNotFound);
            }

            var vm = _mapper.Map<Post, PostViewModel>(post);

            return Result.OK(vm);
        }

        public async Task<IEnumerable<PostViewModel>> GetPostsAsync()
        {
            var posts = await _postRepository.GetAllPostAsync();

            var vm = _mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(posts);

            return vm;
        }

        public Task<Result> UpdatePostAsync(Guid id, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
