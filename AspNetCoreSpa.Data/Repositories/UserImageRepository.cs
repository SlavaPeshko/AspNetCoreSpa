using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Data.Repositories
{
    public class UserImageRepository : BaseRepository<UserImage, int>, IUserImageRepository
    {
        public UserImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task PostAsync(UserImage userImage)
        {
            await GetSet().AddAsync(userImage);
        }

        public async Task<UserImage> GetUserImageByUserIdAsync(int userId)
        {
            return await GetSet().FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public void Put(UserImage userImage)
        {
            GetSet().Attach(userImage);
            DbContext.Entry(userImage).State = EntityState.Modified;
        }
    }
}