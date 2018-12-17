using TestClient.WebApi.Context;

namespace TestClient.WebApi.UoW
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly TestClientContext _testClientContext;

        public UnitOfWorks(TestClientContext testClientContext)
        {
            _testClientContext = testClientContext;
        }

        public bool Commit()
        {
            return _testClientContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _testClientContext.Dispose();
        }
    }
}
