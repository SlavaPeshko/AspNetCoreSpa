using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Infrastructure.Options;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using Image = AspNetCoreSpa.Domain.Entities.Image;

namespace AspNetCoreSpa.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IWebHostEnvironment  _environment;
        private readonly GlobalSettings _settings;
        private readonly IUnitOfWorks _unitOfWorks;

        public FileService(IUserRepository userRepository,
            IImageRepository imageRepository,
            IWebHostEnvironment  environment,
            GlobalSettings settings, IUnitOfWorks unitOfWorks)
        {
            _userRepository = userRepository;
            _imageRepository = imageRepository;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _settings = settings;
            _unitOfWorks = unitOfWorks;
        }
        public async Task<Result<string>> UploadPhotoAsync(Guid id, IFormFile file)
        {
            if (file == null)
                return Result.Fail<string>(EC.ImageInvalid, ET.ImageInvalid);

            if(file.Length > 2_101_156L)
                return Result.Fail<string>(EC.LengthImageInvalid, ET.LengthImageInvalid);
            
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return Result.Fail<string>(EC.UserNotFound, ET.UserNotFound);
            
            using (var stream = file.OpenReadStream())
            {
                using (var image = new Bitmap(stream))
                {
                    int width, height;
                    const int size = 200;
                    const int quality = 4;
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

                        var folderPaths = Path.Combine(_environment.WebRootPath, _settings.Paths.PhotoProfilePath);

                        if (!Directory.Exists(folderPaths))
                            Directory.CreateDirectory(folderPaths);

                        var resultPath = Path.Combine(folderPaths, file.FileName);
                        
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

                var path = Path.Combine(_settings.Paths.PhotoProfilePath, file.FileName);
                var imageProfile = await _imageRepository.GetProfilePhotoByUserId(id);
                if (imageProfile == null)
                {
                    await _imageRepository.PostAsync(new Image
                    {
                        Name = file.FileName,
                        Path = path,
                        UserId = id
                    });
                }
                else
                {
                    imageProfile.Name = file.FileName;
                    imageProfile.Path = path;
                    
                    _imageRepository.Put(imageProfile);
                }

                await _unitOfWorks.CommitAsync();
                
                return Result.OK(path);
            }
        }
    }
}
