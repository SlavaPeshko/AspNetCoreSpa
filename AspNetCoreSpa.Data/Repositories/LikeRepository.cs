using System;
using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Data.Repositories
{
    public class LikeRepository : BaseRepository<Like, int>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Like> GetLikeByIdAsync(int id)
        {
            return await GetSet().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task PostAsync(Like like)
        {
            await GetSet().AddAsync(like);
        }

        public void Put(Like like)
        {
            GetSet().Attach(like);
            DbContext.Entry(like).State = EntityState.Modified;
        }

        public void Delete(Like like)
        {
            GetSet().Remove(like);
        }
    }
}