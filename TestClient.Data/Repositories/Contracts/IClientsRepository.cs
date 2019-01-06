using System.Collections.Generic;
using System.Threading.Tasks;
using TestClient.Domain.Enities;

namespace TestClient.Data.Repositories.Contracts
{
    public interface IClientsRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task PostAsync(Client client);
        void Put(Client client);
        Task<Client> GetClientByIdAsync(int id);
        Task<bool> IsUniqueClientCodeAsync(string clientCode);
    }
}
