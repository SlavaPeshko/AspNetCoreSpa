using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;

namespace AspNetCoreSpa.Data.UoW
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly ApplicationDbContext _AspNetCoreSpaContext;

        public UnitOfWorks(ApplicationDbContext AspNetCoreSpaContext)
        {
            _AspNetCoreSpaContext = AspNetCoreSpaContext;
        }

        public async Task CommitAsync()
        {
            await _AspNetCoreSpaContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _AspNetCoreSpaContext.Dispose();
        }
    }
}
