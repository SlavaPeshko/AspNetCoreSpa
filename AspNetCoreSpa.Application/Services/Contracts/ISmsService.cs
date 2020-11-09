using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ISmsService : IBaseService
    {
        Task<Result> SendSmsAsync(string phoneNumber, string countryCode);
    }
}