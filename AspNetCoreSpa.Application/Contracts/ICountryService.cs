using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.ViewModels;

namespace AspNetCoreSpa.Application.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryViewModel>> GetCountriesAsync();
    }
}
