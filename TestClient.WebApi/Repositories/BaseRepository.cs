using Microsoft.EntityFrameworkCore;
using TestClient.WebApi.Models;

namespace TestClient.WebApi.Repositories
{
    public abstract class BaseRepository<T, TKey> where T : BaseEntity<TKey>
    {
        protected readonly DbContext DbContext;

        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected DbSet<T> GetSet()
        {
            return DbContext.Set<T>();
        }
    }
}
