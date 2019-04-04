using System;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Data.UoW
{
    public interface IUnitOfWorks : IDisposable
    {
        Task CommitAsync();
    }
}
