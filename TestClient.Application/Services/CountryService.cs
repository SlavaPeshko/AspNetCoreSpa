using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestClient.Application.Contracts;
using TestClient.Application.ViewModels;
using TestClinet.Data.Repositories.Contracts;

namespace TestClient.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountriesRepository _countriesRepository;

        public CountryService(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }

        public async Task<IEnumerable<CountryViewModel>> GetCountriesAsync()
        {
            var countries = await _countriesRepository.GetCountriesAsync();

            return countries.Select(x => x.ToViewModel());
        }
    }
}
