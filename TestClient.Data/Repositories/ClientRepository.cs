using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestClient.Data.Context;
using TestClient.Data.Repositories.Contracts;
using TestClient.Domain.Enities;

namespace TestClient.Data.Repositories
{
    public class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        public ClientRepository(TestClientContext dbContext) : base(dbContext)
        {
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await GetSet().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await GetSet()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Post(Client client)
        {
            await GetSet().AddAsync(client);
        }

        public void Put(Client client)
        {
            GetSet().Attach(client);
            DbContext.Entry(client).State = EntityState.Modified;
        }
    }
}
