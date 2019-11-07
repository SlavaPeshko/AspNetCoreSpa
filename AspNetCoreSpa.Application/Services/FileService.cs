using AspNetCoreSpa.Application.Contracts;
using AspNetCoreSpa.Domain.Enities.Base;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EC = AspNetCoreSpa.Domain.Enities.ErrorCode;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;
using AspNetCoreSpa.Application.Options;

namespace AspNetCoreSpa.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _environment;
        private readonly GlobalSettings _settings;

        public FileService(IHostingEnvironment environment,
            GlobalSettings settings)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _settings = settings;
        }
        public async Task<Result<string>> UploadPhotoAsync(IFormFile file)
        {
            await Task.CompletedTask;

            if (file == null)
            {
                return Result.Fail<string>(EC.PhotoInvalid, ET.PhotoInvalid);
            }

            using (var stream = file.OpenReadStream())
            {
                if (stream.Length > 2_101_156L)
                {
                    return Result.Fail<string>(EC.LengthPhotoInvalid, ET.LengthPhotoInvalid);
                }

                var folderPaths = Path.Combine(
                    new[] { _environment.ContentRootPath, "" }.Concat(_settings.Paths.PhotoProfilePath.Split('\\', '/')).ToArray()
                );

                if (!Directory.Exists(folderPaths))
                {
                    Directory.CreateDirectory(folderPaths);
                }

                var resultPath = Path.Combine(folderPaths, file.FileName);
                using (var image = new Bitmap(stream))
                {
                    int width, height;
                    const int size = 900;
                    const int quality = 40;
                    if (image.Width > image.Height)
                    {
                        width = size;
                        height = Convert.ToInt32(image.Height * size / (double)image.Width);
                    }
                    else
                    {
                        width = Convert.ToInt32(image.Width * size / (double)image.Height);
                        height = size;
                    }

                    var resized = new Bitmap(width, height);
                    using (var graphics = Graphics.FromImage(resized))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighSpeed;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.DrawImage(image, 0, 0, width, height);
                        using (var output = File.Open(resultPath, FileMode.Create))
                        {
                            var qualityParamId = Encoder.Quality;
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);
                            var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(x => x.FormatID == ImageFormat.Png.Guid);
                            resized.Save(output, codec, encoderParameters);
                        }
                    }
                }

                return Result.OK(resultPath);
            }
        }
    }
}
