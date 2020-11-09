using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories
{
    public class PostImageRepository : BaseRepository<PostImage, int>, IPostImageRepository
    {
        public PostImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task PostAsync(PostImage image)
        {
            await GetSet().AddAsync(image);
        }

        public async Task PostAsync(List<PostImage> images)
        {
            await GetSet().AddRangeAsync(images);
        }
    }
}