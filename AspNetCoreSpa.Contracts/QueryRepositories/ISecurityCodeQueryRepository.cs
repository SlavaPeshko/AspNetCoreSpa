using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface ISecurityCodeQueryRepository
    {
        Task<string> GetSecurityCodeAsync(int providerType, int codeActionType, string provider, DateTimeOffset time);
        Task<string> GetSecurityCodeAsync(int providerType, int codeActionType, string provider);

        Task<IEnumerable<int>> GetExpiredSecurityCodesAsync();
    }
}