using System;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IImageRepository
    {
        Task PostAsync(PostImage userImage);
        Task<PostImage> GetProfilePhotoByUserId(int id);
        void Put(PostImage userImage);
    }
}