using AspNetCoreSpa.Domain.Enities.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface ISecurityCodesRepository
    {
        Task<IEnumerable<SecurityCode>> GetSecurityCodesAsync(string provider, ProviderType providerType, CodeActionType codeActionType);

        void Delete(SecurityCode securityCode);
        Task CreateAsync(SecurityCode securityCode);
    }
}
