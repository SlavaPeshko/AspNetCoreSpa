﻿using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface IPostQueryRepository
    {
        Task<IEnumerable<PostDto>> GetPagePostsAsync(int size, int page);
    }
}