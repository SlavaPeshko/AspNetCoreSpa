using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Users;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ITokenService : IBaseService
    {
        Task<Result<TokenViewModel>> RefreshToken(TokenModel model);
    }
}