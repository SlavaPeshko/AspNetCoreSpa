using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories
{
    public class PostRepository : BaseRepository<Post, int>, IPostRepository
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(Post post)
        {
            GetSet().Remove(post);
        }

        // public async Task<IEnumerable<Post>> GetAllPostAsync(PostPageFilters filters)
        // {
        //     return await GetSet()
        //         .Include(p => p.Comments)
        //         .Include(p => p.Likes)
        //         .AsNoTracking()
        //         .ToListAsync();
        // }

        public async Task<Post> GetPostByIdAndUserIdAsync(int id, int userId)
        {
            return await GetSet()
                .Include(p=>p.User)
                .SingleOrDefaultAsync(p => p.Id == id && p.User.Id == userId);
        }
        
        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await GetSet().SingleOrDefaultAsync(p => p.Id == id);
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
