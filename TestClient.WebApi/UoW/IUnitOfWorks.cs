using System;

namespace TestClient.WebApi.UoW
{
    public interface IUnitOfWorks : IDisposable
    {
        bool Commit();
    }
}
