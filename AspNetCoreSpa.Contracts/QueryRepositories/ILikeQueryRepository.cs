using System;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface ILikeQueryRepository
    {
        Task<int> GetCountLikePostAsync(int id);
        Task<LikeDto> GetLikeByIdAsync(int id);
    }
}