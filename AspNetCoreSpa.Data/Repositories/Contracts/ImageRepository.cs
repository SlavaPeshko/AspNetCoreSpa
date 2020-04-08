using System;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IImageRepository
    {
        Task PostAsync(Image image);
        Task<Image> GetProfilePhotoByUserId(Guid id);
        void Put(Image image);
    }
}