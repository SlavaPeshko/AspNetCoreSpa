using System;
using System.Threading.Tasks;

namespace TestClient.Data.UoW
{
    public interface IUnitOfWorks : IDisposable
    {
        Task CommitAsync();
    }
}
