using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Contracts;
using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Options;
using AspNetCoreSpa.Domain.Enities;
using Microsoft.Extensions.Caching.Memory;
using TestClinet.Data.Repositories.Contracts;

namespace AspNetCoreSpa.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countriesRepository;
        private readonly IMemoryCache _cache;
        private readonly GlobalSettings _globalSettings;

        public CountryService(ICountryRepository countriesRepository, 
            IMemoryCache cache,
            GlobalSettings globalSettings)
        {
            _countriesRepository = countriesRepository;
            _cache = cache;
            _globalSettings = globalSettings;
        }

        public async Task<IEnumerable<CountryViewModel>> GetCountriesAsync()
        {
            IEnumerable<Country> countries;

            if(!_cache.TryGetValue(CacheKeys.Country, out countries))
            {
                countries = await _countriesRepository.GetCountriesAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(_globalSettings.Cache.CountriesExpiration);

                _cache.Set(CacheKeys.Country, countries, cacheEntryOptions);
            }

            return countries.Select(x => x.ToViewModel());
        }
    }
}
