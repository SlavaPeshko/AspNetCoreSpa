using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreSpa.Data.QueryRepository
{
    public class PostQueryRepository : QueryRepositoryBase, IPostQueryRepository
    {
        public PostQueryRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<PostDto>> GetPagePostsAsync(PostPageFiltersDto filtersDto)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT [Id], [Description], [CreateAt], [UpdateAt], [UserId]
                                   FROM [AspNetCoreSpa].[dbo].[Posts] ORDER BY [CreateAt] DESC
                                    OFFSET @Limit * (@Offset - 1)  ROWS FETCH NEXT @Limit ROWS ONLY";

                return await connection.QueryAsync<PostDto>(query, new { Limit = filtersDto.ItemsPerPage, Offset = filtersDto.PageNumber });
            }
        }

        public async Task<PostDto> GetPostByIdAsync(Guid id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT [Id], [Description], [CreateAt], [UpdateAt], [UserId]
                                   FROM [AspNetCoreSpa].[dbo].[Posts]  WHERE [Id] = @Id";

                return await connection.QueryFirstOrDefaultAsync<PostDto>(query, new { Id = id });
            }
        }
    }
}