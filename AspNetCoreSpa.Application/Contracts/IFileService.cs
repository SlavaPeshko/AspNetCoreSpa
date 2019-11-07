using AspNetCoreSpa.Domain.Enities.Base;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Contracts
{
    public interface IFileService : IBaseService
    {
        Task<Result<string>> UploadPhotoAsync(IFormFile file);
    }
}
