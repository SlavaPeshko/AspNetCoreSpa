using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Infrastructure.Options;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetCoreSpa.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryQueryRepository _countryQueryRepository;
        private readonly IMemoryCache _cache;
        private readonly GlobalSettings _globalSettings;

        public CountryService(ICountryQueryRepository countryQueryRepository,
            IMemoryCache cache,
            GlobalSettings globalSettings)
        {
            _countryQueryRepository = countryQueryRepository;
            _cache = cache;
            _globalSettings = globalSettings;
        }

        public async Task<IEnumerable<CountryViewModel>> GetCountriesAsync()
        {
            IEnumerable<CountryDto> countries;

            if(!_cache.TryGetValue(CacheKeys.Country, out countries))
            {
                countries = await _countryQueryRepository.GetCountriesAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(_globalSettings.Cache.CountriesExpiration);

                _cache.Set(CacheKeys.Country, countries, cacheEntryOptions);
            }

            return countries.Select(x => x.ToViewModel());
        }
    }
}
