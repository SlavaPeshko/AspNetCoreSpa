using System.Collections.Generic;
using System.Threading.Tasks;
using TestClient.Application.ViewModels;

namespace TestClient.Application.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryViewModel>> GetCountriesAsync();
    }
}
