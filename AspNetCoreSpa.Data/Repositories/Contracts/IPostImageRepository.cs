using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IPostImageRepository
    {
        Task PostAsync(PostImage image);
        Task PostAsync(List<PostImage> images);
    }
}