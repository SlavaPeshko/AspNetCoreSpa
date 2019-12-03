using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Domain.Enities.Base;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ITokenService : IBaseService
    {
        Task<Result<UserViewModel>> RefreshToken(string authenticationToken, string refreshToken);
    }
}
