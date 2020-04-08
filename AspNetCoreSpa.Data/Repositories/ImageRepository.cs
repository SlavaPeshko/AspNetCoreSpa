using System;
using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Data.Repositories
{
    public class ImageRepository : BaseRepository<Image, Guid>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task PostAsync(Image image)
        {
            await GetSet().AddAsync(image);
        }

        public async Task<Image> GetProfilePhotoByUserId(Guid id)
        {
            return await GetSet()
                .FirstOrDefaultAsync(x => x.UserId == id && x.PostId == null);
        }
        
        public void Put(Image image)
        {
            GetSet().Attach(image);
            DbContext.Entry(image).State = EntityState.Modified;
        }
    }
}