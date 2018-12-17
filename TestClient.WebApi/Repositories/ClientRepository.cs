using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestClient.WebApi.Models;
using TestClient.WebApi.Repositories.Contracts;

namespace TestClient.WebApi.Repositories
{
    public class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        public ClientRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await GetSet()
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
