using AspNetCoreSpa.Infrastructure.Options;

namespace AspNetCoreSpa.Application.Services.AzureBlobStorage
{
    public class UserPhotoStorageService : BlobStorageService, IUserPhotoStorageService
    {
        public UserPhotoStorageService(GlobalSettings settings) : base(settings)
        {
        }

        protected override string ContainerName { get; } = "profiles";
    }
}