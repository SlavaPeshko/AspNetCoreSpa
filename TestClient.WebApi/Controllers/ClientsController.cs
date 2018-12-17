using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestClient.WebApi.Repositories.Contracts;

namespace TestClient.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _clientRepository.GetClientsAsync());
        }
    }
}