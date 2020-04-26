using System;
using System.Data;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreSpa.Data.QueryRepository
{
    public class LikeQueryRepository : QueryRepositoryBase, ILikeQueryRepository
    {
        public LikeQueryRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<int> GetCountLikePostAsync(int postId)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT SUM(x.likes) 
                                    FROM (
	                                    SELECT -COUNT([Id]) AS likes
	                                    FROM [AspNetCoreSpa].[dbo].[Likes]
	                                    WHERE [PostId] = @id AND [IsLike] = 0
	                                    UNION
	                                    SELECT COUNT([Id]) AS likes
	                                    FROM [AspNetCoreSpa].[dbo].[Likes]
	                                    WHERE [PostId] = @id AND [IsLike] = 1
                                    ) x";

                return await connection.ExecuteScalarAsync<int>(query, new { Id = postId });
            }
        }

        public async Task<LikeDto> GetLikeByIdAsync(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT TOP (1000) [Id], [IsLike], [CommentId], [PostId], [UserId]
                                      FROM [AspNetCoreSpa].[dbo].[Likes]
                                      WHERE [Id] = @id";

                return await connection.QueryFirstOrDefaultAsync<LikeDto>(query, new { Id = id });
            }
        }
    }
}