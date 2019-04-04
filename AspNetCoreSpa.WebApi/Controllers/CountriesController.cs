using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreSpa.Application.Contracts;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var vm = await _countryService.GetCountriesAsync();
            return Ok(vm);
        }
    }
}