using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreSpa.Application.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;

namespace AspNetCoreSpa.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : ApiController
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