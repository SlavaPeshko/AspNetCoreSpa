using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Comments;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ICommentService : IBaseService
    {
        Task<Result> CreateComment(CreateCommentModel model, int id);
    }
}