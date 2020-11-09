using AspNetCoreSpa.Infrastructure.Options;

namespace AspNetCoreSpa.Application.Services.AzureBlobStorage
{
    public class PostImageStorageService : BlobStorageService, IPostImageStorageService
    {
        public PostImageStorageService(GlobalSettings settings) : base(settings)
        {
        }

        protected override string ContainerName { get; } = "posts";
    }
}