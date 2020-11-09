using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(Comment comment)
        {
            GetSet().Remove(comment);
        }

        public async Task PostAsync(Comment comment)
        {
            await GetSet().AddAsync(comment);
        }

        public void Put(Comment comment)
        {
            GetSet().Attach(comment);
            DbContext.Entry(comment).State = EntityState.Modified;
        }
    }
}