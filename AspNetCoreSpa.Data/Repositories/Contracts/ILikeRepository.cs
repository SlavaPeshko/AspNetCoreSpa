using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface ILikeRepository
    {
        Task<Like> GetLikeByIdAsync(int id);
        Task PostAsync(Like like);
        void Put(Like like);
        void Delete(Like like);
    }
}