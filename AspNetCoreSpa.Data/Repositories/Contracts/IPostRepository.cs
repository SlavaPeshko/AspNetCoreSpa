using AspNetCoreSpa.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IPostRepository
    {
        Task PostAsync(Post post);
        void Put(Post post);
        void Delete(Post post);

        Task<IEnumerable<Post>> GetAllPostAsync();
        Task<Post> GetPostByIdAsync(Guid id);
    }
}
