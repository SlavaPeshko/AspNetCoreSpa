using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IPostRepository
    {
        Task PostAsync(Post post);
        void Put(Post post);
        void Delete(Post post);
        Task<Post> GetPostByIdAsync(int id);
        Task<Post> GetPostByIdAndUserIdAsync(int id, int userId);
    }
}
