using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface ICommentRepository
    {
        Task PostAsync(Comment comment);
        void Put(Comment comment);
        void Delete(Comment comment);
    }
}