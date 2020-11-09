using AspNetCoreSpa.Application.Services.Contracts;

namespace AspNetCoreSpa.Application.Services.AzureBlobStorage
{
    public interface IPostImageStorageService : IBlobStorageService, IBaseService
    {
    }
}