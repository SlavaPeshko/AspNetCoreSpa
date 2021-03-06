﻿using System;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Comments;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;

namespace AspNetCoreSpa.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepository;

        public CommentService(ICommentRepository commentRepository,
            IUserContext userContext,
            IUserRepository userRepository,
            IUnitOfWorks unitOfWorks,
            IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _userContext = userContext;
            _userRepository = userRepository;
            _unitOfWorks = unitOfWorks;
            _postRepository = postRepository;
        }

        public async Task<Result> CreateComment(CreateCommentModel model, int id)
        {
            var user = await _userRepository.GetUserByIdAsync(_userContext.UserId);
            if (user == null)
                return Result.Fail(EC.UserNotFound, ET.UserNotFound);

            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null)
                return Result.Fail(EC.PostNotFound, ET.PostNotFound);

            var entity = new Comment
            {
                Description = model.Description,
                CreateAt = DateTime.UtcNow,
                User = user,
                Post = post
            };

            await _commentRepository.PostAsync(entity);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }
    }
}