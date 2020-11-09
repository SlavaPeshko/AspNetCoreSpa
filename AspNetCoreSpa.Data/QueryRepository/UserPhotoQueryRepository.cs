using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreSpa.Data.QueryRepository
{
    public class UserPhotoQueryRepository : QueryRepositoryBase, IUserPhotoQueryRepository
    {
        public UserPhotoQueryRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<UserPhotoDto> GetUserOriginalPhotoAsync(int id)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT TOP (1) [OriginalName] as Name
                                      ,[Path]
                                      ,[Position]
                                  FROM [AspNetCoreSpa].[dbo].[UserPhotos]
                                  WHERE [UserId] = @id AND [Position] IS NOT NULL";

                return await connection.QueryFirstOrDefaultAsync<UserPhotoDto>(query, new {id});
            }
        }
    }
}