using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IFileService : IBaseService
    {
        Task<Result<string>> UploadPhotoAsync(Guid id, IFormFile file);
        Task<Result<List<string>>> UploadImagesAsync(Guid id, Guid postId, List<IFormFile> files);
    }
}
