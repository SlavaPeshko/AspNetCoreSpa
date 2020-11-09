using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities.Security;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface ISecurityCodesRepository
    {
        Task<IEnumerable<SecurityCode>> GetSecurityCodesAsync(string provider, ProviderType providerType,
            CodeActionType codeActionType);

        void Delete(SecurityCode securityCode);
        void Delete(IEnumerable<SecurityCode> securityCodes);
        void Delete(IEnumerable<int> ids);
        Task CreateAsync(SecurityCode securityCode);
    }
}