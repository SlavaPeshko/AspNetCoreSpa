using System;
using System.IO;
using System.Threading.Tasks;
using AspNetCoreSpa.Infrastructure.Options;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreSpa.Application.Services.AzureBlobStorage
{
    public abstract class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        protected BlobStorageService(GlobalSettings settings)
        {
            _blobServiceClient = new BlobServiceClient(settings.AzureStorageConnection.ConnectionString);
        }

        protected abstract string ContainerName { get; }

        public async Task DeleteBlobDataAsync(string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteAsync();
        }

        public async Task<string> UploadFileToBlobAsync(IFormFile file)
        {
            return await UploadFile(file.OpenReadStream(), file.ContentType);
        }

        public async Task<string> UploadFileToBlobAsync(Stream stream, string contentType)
        {
            return await UploadFile(stream, contentType);
        }

        public string GenerateUrl(Guid guid)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            var blobClient =
                containerClient.GetBlobClient($"{guid}");

            var uri = new Uri(containerClient.Uri, blobClient.Uri.AbsolutePath);

            return uri.AbsoluteUri;
        }

        private async Task<string> UploadFile(Stream stream, string contentType)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            var guid = Guid.NewGuid();
            var blobClient = containerClient.GetBlobClient($"{guid}");

            var result = await blobClient.UploadAsync(stream, new BlobHttpHeaders
            {
                ContentType = contentType
            });

            return result.GetRawResponse().Status == StatusCodes.Status201Created ? $"{ContainerName}/{guid}" : null;
        }
    }
}