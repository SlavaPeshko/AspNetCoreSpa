using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Enities.Security;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreSpa.Data.Repositories
{
    public class SecurityCodesRepository : BaseRepository<SecurityCode, Guid>, ISecurityCodesRepository
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

        public async Task<IEnumerable<SecurityCode>> GetSecurityCodesAsync(string provider, ProviderType providerType, CodeActionType codeActionType)
        {
            return await GetSet()
                .Where(s => s.Provider == provider && s.ProviderType == providerType && s.CodeActionType == codeActionType)
                .ToListAsync();
        }
    }
}
