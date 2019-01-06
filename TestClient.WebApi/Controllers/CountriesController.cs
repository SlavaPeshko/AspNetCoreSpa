using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestClient.Application.Contracts;

namespace TestClient.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : Controller
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