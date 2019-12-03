using Microsoft.EntityFrameworkCore;
using AspNetCoreSpa.Domain.Enities.Base;

namespace AspNetCoreSpa.Data.Repositories
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
