using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IFileService : IBaseService
    {
        Task<Result<string>> UploadUserImageAsync(UserImageInputModel model);
        Task<Result<List<string>>> UploadImagesAsync(int id, int postId, List<IFormFile> files);
    }
}
