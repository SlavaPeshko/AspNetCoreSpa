using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using AspNetCoreSpa.Application.Services.Contracts;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var vm = await _countryService.GetCountriesAsync();
            return Ok(vm);
        }
    }
}