﻿using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Models.Post;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IPostService : IBaseService
    {
        Task<IEnumerable<PostViewModel>> GetPostsAsync();
        Task<Result<PostViewModel>> CreatePostAsync(CreatePostInputModel post);
        Task<Result<PostViewModel>> GetPostByIdAsync(Guid id);
        Task<Result> DeletePostByIdAsync(Guid id);
        Task<Result> UpdatePostAsync(Guid id, Post post);
    }
}