using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreSpa.Data.QueryRepository
{
    public class UserQueryRepository : QueryRepositoryBase, IUserQueryRepository
    {
        public UserQueryRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT TOP(1) [dbo].[Users].[Id], [FirstName], [LastName]
                                      ,[Email], [EmailConfirmed], [PhoneNumber]
                                      ,[PhoneNumberConfirmed], [PasswordHash], [AccessFailedCount]
                                      ,[DateOfBirth], [Gender], [RefreshToken]
									  ,[dbo].[UserPhotos].[Id], [dbo].[UserPhotos].[OriginalName]
									  ,[dbo].[UserPhotos].[Path]
									  ,[dbo].[Addresses].[Id]
									  ,[dbo].[Addresses].[Address1]
									  ,[dbo].[Addresses].[Address2]
									  ,[dbo].[Addresses].[City]
									  ,[dbo].[Addresses].[Postcode]
									  ,[dbo].[Countries].[Id] AS CountryId
									  ,[dbo].[Countries].[Name] AS CountryName
                                      FROM [dbo].[Users]
									  LEFT JOIN [dbo].[UserPhotos] ON [dbo].[UserPhotos].[UserId] = [dbo].[Users].[Id] AND [dbo].[UserPhotos].[Position] IS NULL
									  LEFT JOIN [dbo].[XreUserAddress] ON [dbo].[XreUserAddress].[UserId] = [dbo].[Users].[Id]
									  LEFT JOIN [dbo].[Addresses] ON [dbo].[Addresses].[Id] = [dbo].[XreUserAddress].[AddressId]
									  LEFT JOIN [dbo].[Countries] ON [dbo].[Countries].[Id] = [dbo].[Addresses].[CountryId]
									  WHERE [dbo].[Users].[Id] = @Id";

                var user = await connection.QueryAsync<UserDto, ImageDto, AddressDto, UserDto>(query,
                    (userDto, imageDto, addressDto) =>
                    {
                        var userDtoEntry = userDto;

                        if (addressDto != null)
                            userDtoEntry.Address = addressDto;

                        if (imageDto != null)
                            userDto.ImageDto = imageDto;

                        return userDtoEntry;
                    },
                    new {Id = id},
                    splitOn: "Id, Id, Id");

                return user.FirstOrDefault();
            }
        }

        public async Task<bool> IsExistEmailAsync(string email)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT COUNT(1) FROM [AspNetCoreSpa].[dbo].[Users] WHERE [Email] = @email";

                return await connection.ExecuteScalarAsync<bool>(query, new {Email = email});
            }
        }

        public async Task<bool> IsExistUserAsync(int id)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT COUNT(1) FROM [AspNetCoreSpa].[dbo].[Users] WHERE [Id] = @id";

                return await connection.ExecuteScalarAsync<bool>(query, new {id});
            }
        }

        public async Task<bool> IsExistPhoneAsync(string phoneNumber)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT COUNT(1) FROM [AspNetCoreSpa].[dbo].[Users] WHERE [PhoneNumber] = @phone";

                return await connection.ExecuteScalarAsync<bool>(query, new {Phone = phoneNumber});
            }
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT TOP (1) [Id]
                                  FROM [AspNetCoreSpa].[dbo].[Users]
                                  WHERE [Email] = @email";

                var user = await connection.QueryAsync<UserDto>(query, new {email});

                return user.FirstOrDefault();
            }
        }

        public async Task<UserDto> GetUserWithRolesByIdAsync(int id)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT TOP (1) [Users].[Id], [FirstName], [LastName] ,[Email], [PhoneNumber]
                                      , [DateOfBirth], [Gender], [Roles].[Id] AS RolesId
                                  FROM [AspNetCoreSpa].[dbo].[Users]
                                  LEFT JOIN [AspNetCoreSpa].[dbo].[XrefUserRole] ON [XrefUserRole].[UserId] = [Users].[Id]
                                  LEFT JOIN [AspNetCoreSpa].[dbo].[Roles] ON [Roles].[Id] = [XrefUserRole].[RoleId]
                                  WHERE [Users].[Id] = @id";

                var user = await connection.QueryAsync<UserDto, int?, UserDto>(query,
                    (userDto, role) =>
                    {
                        var userDtoEntry = userDto;

                        if (role.HasValue)
                            userDtoEntry.Roles.Add(role.Value);

                        return userDtoEntry;
                    },
                    new {Id = id},
                    splitOn: "Name, Id, Id, Name");

                return user.FirstOrDefault();
            }
        }
    }
}