using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Data.QueryRepository
{
    public class UserQueryRepository : QueryRepositoryBase, IUserQueryRepository
    {
        public UserQueryRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT TOP(1) [FirstName], [LastName]
                                      ,[Email], [EmailConfirmed], [PhoneNumber]
                                      ,[PhoneNumberConfirmed], [PasswordHash], [AccessFailedCount]
                                      ,[DateOfBirth], [Gender], [RefreshToken], [CountryId]
                                      FROM [dbo].[Users]
                                      WHERE [Id] = @Id";

                var user = await connection.QueryFirstOrDefaultAsync<UserDto>(query, new { Id = id });

                if (user.CountryId.HasValue)
                {
                    user.CountryDto = await connection
                        .QueryFirstAsync<CountryDto>(@"SELECT TOP (1) [Name] FROM[AspNetCoreSpa].[dbo].[Countries] WHERE Id = @id",
                                                                new { Id = user.CountryId });
                }

                return user;
            }
        }

        public async Task<bool> IsExistEmailAsync(string email)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT COUNT(1) FROM [AspNetCoreSpa].[dbo].[Users] WHERE [Email] = @email";
                
                return await connection.ExecuteScalarAsync<bool>(query, new { Email = email });
            }
        }
    }
}
