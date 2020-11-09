using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Models.Users;
using AspNetCoreSpa.Domain.Entities.Base;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IFileService : IBaseService
    {
        Task<Result<string>> UploadUserImageAsync(UserImageInputModel model);
        Task<Result<List<string>>> UploadImagesAsync(int postId, List<IFormFile> files);
        Task<Result<UserPhotoViewModel>> GetUserImageAsync();
    }
}