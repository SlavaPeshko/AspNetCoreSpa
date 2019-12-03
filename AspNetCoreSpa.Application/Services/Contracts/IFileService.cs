using AspNetCoreSpa.Domain.Enities.Base;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IFileService : IBaseService
    {
        Task<Result<string>> UploadPhotoAsync(IFormFile file);
    }
}
