using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestClient.Application.Services.Contracts;
using TestClient.Domain.Models;

namespace TestClient.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService; 

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
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