using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Data.Repositories
{
    public class PostRepository : BaseRepository<Post, Guid>, IPostRepository
    {
        public PostRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(Post post)
        {
            GetSet().Remove(post);
        }

        public async Task<IEnumerable<Post>> GetAllPostAsync()
        {
            return await GetSet()
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(Guid id)
        {
            return await GetSet().SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task PostAsync(Post post)
        {
            await GetSet().AddAsync(post);
        }

        public void Put(Post post)
        {
            GetSet().Attach(post);
            DbContext.Entry(post).State = EntityState.Modified;
        }
    }
}
