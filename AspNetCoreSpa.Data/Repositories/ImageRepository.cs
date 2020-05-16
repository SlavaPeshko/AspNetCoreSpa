using System;
using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Data.Repositories
{
    public class ImageRepository : BaseRepository<PostImage, int>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task PostAsync(PostImage userImage)
        {
            await GetSet().AddAsync(userImage);
        }

        public async Task<PostImage> GetProfilePhotoByUserId(int id)
        {
            return await GetSet()
                .FirstOrDefaultAsync(x => x.PostId == null);
        }
        
        public void Put(PostImage userImage)
        {
            GetSet().Attach(userImage);
            DbContext.Entry(userImage).State = EntityState.Modified;
        }
    }
}