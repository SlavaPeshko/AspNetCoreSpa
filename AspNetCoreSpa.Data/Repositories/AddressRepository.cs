using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address, int>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task PostAsync(Address address)
        {
            await GetSet().AddAsync(address);
        }

        public void Put(Address address)
        {
            GetSet().Attach(address);
            DbContext.Entry(address).State = EntityState.Modified;
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await GetSet().SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}