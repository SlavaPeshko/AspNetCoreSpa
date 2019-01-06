using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestClient.Data.Context;
using TestClient.Data.Repositories.Contracts;
using TestClient.Domain.Enities;

namespace TestClient.Data.Repositories
{
    public class ClientsRepository : BaseRepository<Client, int>, IClientsRepository
    {
        public ClientsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await GetSet().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await GetSet()
                .Include(c => c.Country)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task PostAsync(Client client)
        {
            await GetSet().AddAsync(client);
        }

        public void Put(Client client)
        {
            GetSet().Attach(client);
            DbContext.Entry(client).State = EntityState.Modified;
        }

        public async Task<bool> IsUniqueClientCodeAsync(string clientCode)
        {
            return await GetSet().AnyAsync(c => c.ClinetCode.ToUpperInvariant() == clientCode.ToUpperInvariant());
        }
    }
}
