using System.Collections.Generic;
using System.Threading.Tasks;
using TestClient.WebApi.Models;

namespace TestClient.WebApi.Repositories.Contracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
    }
}
