using AspNetCoreSpa.Application.Models;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ITokenService : IBaseService
    {
        Task<Result<TokenViewModel>> RefreshToken(TokenInputModel model);
    }
}
