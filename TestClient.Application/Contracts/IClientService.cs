using System.Collections;
using System.Threading.Tasks;
using TestClient.Domain.Enities;

namespace TestClient.Application.Services.Contracts
{
    public interface IClientService
    {
        Task<IEnumerable> GetClientsAsync();
        Task Post(Client client);
        void Put(Client client);
    }
}
