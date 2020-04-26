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

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT TOP(1) [dbo].[Users].[Id], [FirstName], [LastName]
                                      ,[Email], [EmailConfirmed], [PhoneNumber]
                                      ,[PhoneNumberConfirmed], [PasswordHash], [AccessFailedCount]
                                      ,[DateOfBirth], [Gender], [RefreshToken]
									  ,[dbo].[Images].[Id], [dbo].[Images].[Name]
									  ,[dbo].[Images].[Path]
									  ,[dbo].[Addresses].[Id]
									  ,[dbo].[Addresses].[Address1]
									  ,[dbo].[Addresses].[Address2]
									  ,[dbo].[Addresses].[City]
									  ,[dbo].[Addresses].[Postcode]
									  ,[dbo].[Countries].[Id] AS CountryId
									  ,[dbo].[Countries].[Name] AS CountryName
                                      FROM [dbo].[Users]
									  LEFT JOIN [dbo].[Images] ON [dbo].[Images].[UserId] = [dbo].[Users].[Id] AND [dbo].[Images].[PostId] IS NULL
									  LEFT JOIN [dbo].[XreUserAddress] ON [dbo].[XreUserAddress].[UserId] = [dbo].[Users].[Id]
									  LEFT JOIN [dbo].[Addresses] ON [dbo].[Addresses].[Id] = [dbo].[XreUserAddress].[AddressId]
									  LEFT JOIN [dbo].[Countries] ON [dbo].[Countries].[Id] = [dbo].[Addresses].[CountryId]
                                      WHERE [dbo].[Users].[Id] = @Id";

                var user = await connection.QueryAsync<UserDto, ImageDto, AddressDto, UserDto>(query,
                    (userDto, imageDto, addressDto) =>
                    {
                        UserDto userDtoEntry = userDto;

                        if (addressDto != null)
                            userDtoEntry.Address = addressDto;

                        if (imageDto != null)
                            userDto.ImageDto = imageDto;

                        return userDtoEntry;
                    },
                    new {Id = id},
                    splitOn: "Name, Id, Id, Name");

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
