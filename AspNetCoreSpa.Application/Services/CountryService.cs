using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Contracts;
using AspNetCoreSpa.Application.Models;
using TestClinet.Data.Repositories.Contracts;

namespace AspNetCoreSpa.Application.Services
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
