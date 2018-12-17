using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestClient.WebApi.Context;
using TestClient.WebApi.Models;
using TestClient.WebApi.Repositories.Contracts;
using TestClient.WebApi.ViewModels;

namespace TestClient.WebApi.Repositories
{
    public class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        public ClientRepository(TestClientContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ClientViewModel>> GetClientsAsync()
        {
            return await GetSet()
                .Select(c => new ClientViewModel
                {
                    ClientName = c.ClientName,
                    ClientCode = c.ClinetCode,
                    CountryName = c.Country.CountryName,
                    CountryRegioneCode = c.Country.CountryRegioneCode
                })
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
