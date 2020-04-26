using AspNetCoreSpa.Application.Models.Comment;
using AspNetCoreSpa.Domain.Entities.Base;
using System;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface ICommentService : IBaseService
    {
        Task<Result> CreateComment(CreateCommentInputModel model, int id);
    }
}
