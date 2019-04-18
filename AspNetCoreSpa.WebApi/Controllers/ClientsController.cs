using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Application.Models;

namespace AspNetCoreSpa.WebApi.Controllers
{
    //[Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IUserService _clientService; 

        public ClientsController(IUserService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var vm = await _clientService.GetUsersAsync();
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CreateUserInputModel model)
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