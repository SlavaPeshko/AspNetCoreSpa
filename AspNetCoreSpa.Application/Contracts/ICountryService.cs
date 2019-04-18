using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models;

namespace AspNetCoreSpa.Application.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryViewModel>> GetCountriesAsync();
    }
}
