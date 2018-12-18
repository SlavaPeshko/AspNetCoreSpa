using System;
using System.Collections;
using System.Threading.Tasks;
using TestClient.Application.Services.Contracts;
using TestClient.Data.Repositories.Contracts;
using TestClient.Data.UoW;
using TestClient.Domain.Enities;

namespace TestClient.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IClientRepository _clientRepository;

        public ClientService(IUnitOfWorks unitOfWorks, IClientRepository clientRepository)
        {
            _unitOfWorks = unitOfWorks;
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable> GetClientsAsync()
        {
            return await _clientRepository.GetClientsAsync();
        }

        public Task Post(Client client)
        {
            throw new NotImplementedException();
        }

        public void Put(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
