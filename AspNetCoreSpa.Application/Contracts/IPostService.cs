using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Domain.Enities;
using AspNetCoreSpa.Domain.Enities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Contracts
{
    public interface IPostService : IBaseService
    {
        Task<IEnumerable<PostViewModel>> GetPostsAsync();
        Task<Result<PostViewModel>> CreatePostAsync(Post post);
    }
}
