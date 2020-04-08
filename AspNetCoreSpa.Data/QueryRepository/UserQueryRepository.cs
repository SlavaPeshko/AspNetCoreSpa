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
                string query = @"SELECT TOP(1) [dbo].[Users].[Id], [FirstName], [LastName]
                                      ,[Email], [EmailConfirmed], [PhoneNumber]
                                      ,[PhoneNumberConfirmed], [PasswordHash], [AccessFailedCount]
                                      ,[DateOfBirth], [Gender], [RefreshToken], [CountryId]
									  ,[dbo].[Countries].[Name], [dbo].[Countries].[RegionCode]
									  ,[dbo].[Images].[Id], [dbo].[Images].[Name]
									  ,[dbo].[Images].[Path]
                                      FROM [dbo].[Users]
									  LEFT JOIN [dbo].[Countries] ON [dbo].[Countries].[Id] = [dbo].[Users].[CountryId]
									  LEFT JOIN [dbo].[Images] ON [dbo].[Images].[UserId] = [dbo].[Users].[Id] AND [dbo].[Images].[PostId] IS NULL
                                      WHERE [dbo].[Users].[Id] = @Id";

                var user = await connection.QueryAsync<UserDto, CountryDto, ImageDto, UserDto>(query,
                    (userDto, countryDto, imageDto) =>
                    {
                        UserDto userDtoEntry = userDto;

                        if (countryDto != null)
                            userDtoEntry.CountryDto = countryDto;

                        if (imageDto != null)
                            userDto.ImageDto = imageDto;

                        return userDtoEntry;
                    },
                    new {Id = id},
                    splitOn: "Name, Id");

                return user.FirstOrDefault();
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
