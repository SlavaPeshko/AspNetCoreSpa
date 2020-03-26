using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Services;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Infrastructure.Options;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;

namespace AspNetCoreSpa.Tests.Unit.Country
{
    [TestFixture]
    [Category("country")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CountryServiceTest
    {
        private ICountryService _countryService;
        private Mock<ICountryQueryRepository> _countryQueryRepository;
        private Mock<IMemoryCache> _cache;
        private GlobalSettings _globalSettings;

        delegate void OutDelegate<TIn, TOut>(TIn input, out TOut output);

        [SetUp]
        public void Setup()
        {
            _countryQueryRepository = new Mock<ICountryQueryRepository>();
            _cache = new Mock<IMemoryCache>();
            _globalSettings = new GlobalSettings
            {
                Cache = new Cache
                {
                    CountriesExpiration = new TimeSpan(7200)
                }
            };

            _countryService = new CountryService(_countryQueryRepository.Object, _cache.Object, _globalSettings);
            _countryQueryRepository.Setup(_ => _.GetCountriesAsync()).ReturnsAsync(new List<CountryDto>
            {
                new CountryDto
                {
                    Name = "Belarus",
                    RegionCode = "BLR"
                }
            });
        }

        //[Test]
        //public async Task CheckCountCountyList()
        //{
        //    // Act 
        //    var result = await _countryService.GetCountriesAsync();
            
        //    // Assert 
        //    Assert.IsTrue(result.Any());
        //}
    }
}