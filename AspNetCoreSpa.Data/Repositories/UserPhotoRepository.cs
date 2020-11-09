using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Data.Repositories
{
    public class UserPhotoRepository : BaseRepository<UserPhoto, int>, IUserPhotoRepository
    {
        public UserPhotoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task PostAsync(UserPhoto userPhoto)
        {
            await GetSet().AddAsync(userPhoto);
        }

        public async Task<UserPhoto> GetUserPhotoById(int id)
        {
            return await GetSet()
                .FirstOrDefaultAsync(x => x.UserId == id);
        }

        public void Put(UserPhoto userPhoto)
        {
            GetSet().Attach(userPhoto);
            DbContext.Entry(userPhoto).State = EntityState.Modified;
        }
    }
}