using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using System;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface IUserQueryRepository
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<bool> IsExistEmailAsync(string email);
        Task<UserDto> GetUserWithRolesByIdAsync(int id);
        Task<bool> IsExistUserAsync(int id);
    }
}
