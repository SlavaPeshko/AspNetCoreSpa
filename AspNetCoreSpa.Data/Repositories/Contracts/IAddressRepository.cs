using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IAddressRepository
    {
        Task PostAsync(Address address);
        void Put(Address address);

        Task<Address> GetAddressByIdAsync(int id);
    }
}