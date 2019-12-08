using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IFileService : IBaseService
    {
        Task<Result<string>> UploadPhotoAsync(IFormFile file);
    }
}
