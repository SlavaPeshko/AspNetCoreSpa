using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IUserPhotoRepository
    {
        Task PostAsync(UserPhoto userPhoto);
        Task<UserPhoto> GetUserPhotoById(int id);
        void Put(UserPhoto userPhoto);
    }
}