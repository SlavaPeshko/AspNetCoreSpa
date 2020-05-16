using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IUserImageRepository
    {
        Task PostAsync(UserImage userImage);
        Task<UserImage> GetUserImageByUserIdAsync(int userId);
        void Put(UserImage userImage);
    }
}