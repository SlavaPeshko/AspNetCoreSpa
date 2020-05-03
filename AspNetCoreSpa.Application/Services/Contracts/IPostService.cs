using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Models.Post;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IPostService : IBaseService
    {
        Task<IEnumerable<PostViewModel>> GetPostsAsync(PostPageFilters filters);
        Task<Result<PostViewModel>> CreatePostAsync(CreatePostInputModel post);
        Task<Result<PostViewModel>> GetPostByIdAsync(int id);
        Task<Result> DeletePostByIdAsync(int id);
        Task<Result> UpdatePostAsync(int id, UpdatePostInputModel post);
    }
}
