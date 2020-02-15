using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment, Guid>, ICommentRepository
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
