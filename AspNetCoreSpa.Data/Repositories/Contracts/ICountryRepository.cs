using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Enities;

namespace TestClinet.Data.Repositories.Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
    }
}
