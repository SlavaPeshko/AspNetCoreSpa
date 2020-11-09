using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Data.Repositories
{
    public class SecurityCodesRepository : BaseRepository<SecurityCode, int>, ISecurityCodesRepository
    {
        public SecurityCodesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(SecurityCode securityCode)
        {
            await GetSet().AddAsync(securityCode);
        }

        public void Delete(SecurityCode securityCode)
        {
            GetSet().Remove(securityCode);
        }

        public void Delete(IEnumerable<SecurityCode> securityCodes)
        {
            GetSet().RemoveRange(securityCodes);
        }

        public void Delete(IEnumerable<int> ids)
        {
            GetSet().RemoveRange(GetSet().Where(x => ids.Contains(x.Id)));
        }

        public async Task<IEnumerable<SecurityCode>> GetSecurityCodesAsync(string provider, ProviderType providerType,
            CodeActionType codeActionType)
        {
            return await GetSet()
                .Where(s => s.Provider == provider && s.ProviderType == providerType &&
                            s.CodeActionType == codeActionType)
                .ToListAsync();
        }
    }
}