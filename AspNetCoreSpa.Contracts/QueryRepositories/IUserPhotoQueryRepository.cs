using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface IUserPhotoQueryRepository
    {
        Task<UserPhotoDto> GetUserOriginalPhotoAsync(int id);
    }
}