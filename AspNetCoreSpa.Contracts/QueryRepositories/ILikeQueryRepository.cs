using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface ILikeQueryRepository
    {
        Task<int> GetRatingByPostIdAsync(int id);
        Task<LikeDto> GetLikeByIdAsync(int id);

        Task<IEnumerable<LikeDto>> GetLikesByPostIdAsync(int postId, int userId);
    }
}