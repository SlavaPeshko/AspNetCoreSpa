using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ISecurityCodeService : IBaseService
    {
        Task RemoveExpiredSecurityCodesAsync();
    }
}