using AspNetCoreSpa.Domain.Entities;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface ICommentRepository
    {
        Task PostAsync(Comment comment);
        void Put(Comment comment);
        void Delete(Comment comment);
    }
}
