using AspNetCoreSpa.Application.Models;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ITokenService : IBaseService
    {
        Task<Result<UserViewModel>> RefreshToken(string authenticationToken, string refreshToken);
    }
}
