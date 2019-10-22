using AspNetCoreSpa.Application.Contracts;
using AspNetCoreSpa.Domain.Enities.Base;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EC = AspNetCoreSpa.Domain.Enities.ErrorCode;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _environment;

        public FileService(IHostingEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public async Task<Result> UploadPhotoAsync(Stream stream, string fileName, string path)
        {
            if (stream == null)
            {
                return Result.Fail(EC.PhotoInvalid, ET.PhotoInvalid);
            }

            if (stream.Length > 2_101_156L) {
                    return Result.Fail(EC.LengthPhotoInvalid, ET.LengthPhotoInvalid);
            }

            var folderPaths = Path.Combine(
                new[] { _environment.ContentRootPath, "" }.Concat(path.Split('\\', '/')).ToArray()
            );

            Directory.CreateDirectory(folderPaths);

            var resultPath = Path.Combine(folderPaths, fileName);
            using (var s = new MemoryStream())
            using (var fs = new FileStream(resultPath, FileMode.Create))
            {
                await stream.CopyToAsync(s);
                s.Position = 0;
                ImageOptimizer optimizer = new ImageOptimizer();
                optimizer.Compress(s);
                await s.CopyToAsync(fs);
            }

            return Result.OK(new object());
        }
    }
}
