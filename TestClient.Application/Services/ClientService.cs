using System;
using System.Collections;
using System.Threading.Tasks;
using TestClient.Application.Services.Contracts;
using TestClient.Application.ViewModels;
using TestClient.Data.Repositories.Contracts;
using TestClient.Data.UoW;
using TestClient.Domain.Enities;
using TestClient.Domain.Models;

namespace TestClient.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IClientsRepository _clientRepository;

        public ClientService(IUnitOfWorks unitOfWorks, IClientsRepository clientRepository)
        {
            _unitOfWorks = unitOfWorks;
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable> GetClientsAsync()
        {
            return await _clientRepository.GetClientsAsync();
        }

        public async Task<ClientViewModel> PostAsync(CreateClientModel createClientModel)
        {
            var client = new Client
            {
                ClientName = createClientModel.ClientName,
                ClinetCode = createClientModel.ClientCode,
                CountryId = createClientModel.CountryId
            };

            await _clientRepository.PostAsync(client);
            await _unitOfWorks.CommitAsync();

            return client.ToEntity();
        }

        public void Put(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
