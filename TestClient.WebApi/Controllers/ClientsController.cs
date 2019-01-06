using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestClient.Application.Services.Contracts;
using TestClient.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace TestClient.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService; 

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var vm = await _clientService.GetClientsAsync();
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CreateClientModel model)
        {
            var vm = await _clientService.PostAsync(model);
            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync()
        {
            await Task.CompletedTask;

            return Ok();
        }
    }
}