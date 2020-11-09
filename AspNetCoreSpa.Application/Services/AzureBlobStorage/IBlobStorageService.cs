using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreSpa.Application.Services.AzureBlobStorage
{
    public interface IBlobStorageService
    {
        Task DeleteBlobDataAsync(string blobName);
        Task<string> UploadFileToBlobAsync(IFormFile file);
        Task<string> UploadFileToBlobAsync(Stream stream, string contentType);
    }
}