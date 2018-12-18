using System.Collections.Generic;
using System.Threading.Tasks;
using TestClient.Domain.Enities;

namespace TestClient.Data.Repositories.Contracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task Post(Client client);
        void Put(Client client);
        Task<Client> GetClientByIdAsync(int id);
    }
}
