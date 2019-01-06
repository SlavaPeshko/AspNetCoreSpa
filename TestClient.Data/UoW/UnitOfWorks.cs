using System.Threading.Tasks;
using TestClient.Data.Context;

namespace TestClient.Data.UoW
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly ApplicationDbContext _testClientContext;

        public UnitOfWorks(ApplicationDbContext testClientContext)
        {
            _testClientContext = testClientContext;
        }

        public async Task CommitAsync()
        {
            await _testClientContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _testClientContext.Dispose();
        }
    }
}
