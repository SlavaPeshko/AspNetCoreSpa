using System.Collections.Generic;
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

        public async Task<int> GetRatingByPostIdAsync(int postId)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT SUM(x.likes) 
                                    FROM (
	                                    SELECT -COUNT([Id]) AS likes
	                                    FROM [AspNetCoreSpa].[dbo].[Likes]
	                                    WHERE [PostId] = @id AND [IsLike] = 0
	                                    UNION
	                                    SELECT COUNT([Id]) AS likes
	                                    FROM [AspNetCoreSpa].[dbo].[Likes]
	                                    WHERE [PostId] = @id AND [IsLike] = 1
                                    ) x";

                return await connection.ExecuteScalarAsync<int>(query, new {Id = postId});
            }
        }

        public async Task<LikeDto> GetLikeByIdAsync(int id)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT TOP (1000) [Id], [IsLike], [CommentId], [PostId], [UserId]
                                      FROM [AspNetCoreSpa].[dbo].[Likes]
                                      WHERE [Id] = @id";

                return await connection.QueryFirstOrDefaultAsync<LikeDto>(query, new {Id = id});
            }
        }

        public async Task<IEnumerable<LikeDto>> GetLikesByPostIdAsync(int postId, int userId)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT TOP (1000) [Id], [IsLike], [CommentId], [PostId], [UserId]
                                  FROM [AspNetCoreSpa].[dbo].[Likes]
                                  WHERE [Likes].[PostId] = @postId AND [Likes].[UserId] = @userId";

                return await connection.QueryAsync<LikeDto>(query, new {postId, userId});
            }
        }
    }
}