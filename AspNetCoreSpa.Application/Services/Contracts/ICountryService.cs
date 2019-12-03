using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ICountryService : IBaseService
    {
        Task<IEnumerable<CountryViewModel>> GetCountriesAsync();
    }
}
