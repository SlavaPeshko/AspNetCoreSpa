using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface IPostQueryRepository
    {
        Task<IEnumerable<PostDto>> GetPagePostsAsync(PostPageFiltersDto filtersDto);
        Task<PostDto> GetPostByIdAsync(int id);
        Task<bool> IsExistPostAsync(int id);
    }
}