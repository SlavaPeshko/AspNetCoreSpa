using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Like;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ILikeService : IBaseService
    {
        Task<Result> DeleteLikeByIdAsync(int id);
        Task<int> GetRatingByPostIdAsync(int postId);
        Task<Result<LikeViewModel>> CreateLikePostAsync(int? postId, bool isLike);
    }
}