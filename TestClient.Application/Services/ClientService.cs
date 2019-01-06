using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<ClientViewModel>> GetClientsAsync()
        {
            var clients = await _clientRepository.GetClientsAsync();

            return clients.Select(c => c.ToEntity());
        }

        public async Task<CreateClientModel> PostAsync(CreateClientModel createClientModel)
        {
            var isUniqueClientCode = await _clientRepository.IsUniqueClientCodeAsync(createClientModel.ClientCode);
            if (isUniqueClientCode)
            {
                //return 
            }

            var client = new Client
            {
                ClientName = createClientModel.ClientName,
                ClinetCode = createClientModel.ClientCode,
                CountryId = createClientModel.CountryId
            };

            await _clientRepository.PostAsync(client);
            await _unitOfWorks.CommitAsync();

            return createClientModel;
        }

        public void Put(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
