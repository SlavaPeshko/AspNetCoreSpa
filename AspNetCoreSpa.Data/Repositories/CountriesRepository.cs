using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories;
using AspNetCoreSpa.Domain.Enities;
using TestClinet.Data.Repositories.Contracts;

namespace TestClinet.Data.Repositories
{
    public class CountriesRepository : BaseRepository<Country, Guid>, ICountriesRepository
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
