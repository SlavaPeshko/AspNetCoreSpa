using System;

namespace TestClient.Data.UoW
{
    public interface IUnitOfWorks : IDisposable
    {
        bool Commit();
    }
}
