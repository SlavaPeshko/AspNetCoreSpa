using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestClient.WebApi.Models;
using TestClient.WebApi.Repositories.Contracts;
using TestClient.WebApi.UoW;

namespace TestClient.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWorks _unitOfWorks;

        public ClientsController(IClientRepository clientRepository, IUnitOfWorks unitOfWorks)
        {
            _clientRepository = clientRepository;
            _unitOfWorks = unitOfWorks;
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Client client)
        {
            await _clientRepository.Post(client);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync()
        {
            return null;
        }
    }
}