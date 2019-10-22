using AspNetCoreSpa.Domain.Enities.Base;
using System.IO;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Contracts
{
    public interface IFileService : IBaseService
    {
        Task<Result> UploadPhotoAsync(Stream stream, string fileName, string path);
    }
}
