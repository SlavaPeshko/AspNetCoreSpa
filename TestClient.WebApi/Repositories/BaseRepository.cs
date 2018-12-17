using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestClient.WebApi.Models;

namespace TestClient.WebApi.Repositories
{
    public abstract class BaseRepository<T, TKey> where T : BaseEntity<TKey>
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbSet<T> GetSet()
        {
            return _dbContext.Set<T>();
        }
    }
}
