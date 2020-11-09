using AspNetCoreSpa.Application.Services.Contracts;

namespace AspNetCoreSpa.Application.Services.AzureBlobStorage
{
    public interface IUserPhotoStorageService : IBlobStorageService, IBaseService
    {
    }
}