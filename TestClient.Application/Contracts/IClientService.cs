using System.Collections.Generic;
using System.Threading.Tasks;
using TestClient.Application.ViewModels;
using TestClient.Domain.Enities;
using TestClient.Domain.Models;

namespace TestClient.Application.Services.Contracts
{
    public interface IClientService
    {
        Task<IEnumerable<ClientViewModel>> GetClientsAsync();
        Task<CreateClientModel> PostAsync(CreateClientModel createClientModel);
        void Put(Client client);
    }
}
