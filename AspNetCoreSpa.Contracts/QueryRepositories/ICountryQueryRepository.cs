using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface ICountryQueryRepository
    {
        Task<IEnumerable<CountryDto>> GetCountriesAsync();
    }
}
