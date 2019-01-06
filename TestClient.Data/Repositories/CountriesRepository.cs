using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestClient.Data.Context;
using TestClient.Data.Repositories;
using TestClient.Domain.Enities;
using TestClinet.Data.Repositories.Contracts;

namespace TestClinet.Data.Repositories
{
    public class CountriesRepository : BaseRepository<Client, int>, ICountriesRepository
    {
        public CountriesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await DbContext.Set<Country>()
                .ToListAsync();
        }
    }
}
