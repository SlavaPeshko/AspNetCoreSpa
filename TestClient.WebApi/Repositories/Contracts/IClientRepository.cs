using System.Collections.Generic;
using System.Threading.Tasks;
using TestClient.WebApi.Models;
using TestClient.WebApi.ViewModels;

namespace TestClient.WebApi.Repositories.Contracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<ClientViewModel>> GetClientsAsync();
        Task Post(Client client);
        void Put(Client client);
    }
}
