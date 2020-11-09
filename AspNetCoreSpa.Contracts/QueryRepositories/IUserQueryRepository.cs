using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface IUserQueryRepository
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<bool> IsExistEmailAsync(string email);
        Task<UserDto> GetUserWithRolesByIdAsync(int id);
        Task<bool> IsExistUserAsync(int id);
        Task<bool> IsExistPhoneAsync(string phoneNumber);
        Task<UserDto> GetUserByEmailAsync(string email);
    }
}