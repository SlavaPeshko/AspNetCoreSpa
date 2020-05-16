using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using AspNetCoreSpa.Application.Models;
using Microsoft.AspNetCore.Http;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Infrastructure.Options;
using NetTopologySuite.Geometries;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using NetTopologySuite.Geometries;

namespace AspNetCoreSpa.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserContext _userContext;
        private readonly IWebHostEnvironment _environment;
        private readonly GlobalSettings _settings;
        private readonly IUnitOfWorks _unitOfWorks;

        public FileService(IUserRepository userRepository,
            IImageRepository imageRepository,
            IUserImageRepository userImageRepository,
            UserContext userContext,
            IWebHostEnvironment environment,
            GlobalSettings settings, IUnitOfWorks unitOfWorks)
        {
            _userRepository = userRepository;
            _imageRepository = imageRepository;
            _userImageRepository = userImageRepository;
            _userContext = userContext;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _settings = settings;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Result<List<string>>> UploadImagesAsync(int id, int postId, List<IFormFile> files)
        {
            if (files == null)
                return Result.Fail<List<string>>(EC.ImageInvalid, ET.ImageInvalid);

            if (files.Any(file => file.Length > 2_101_156L))
            {
                return Result.Fail<List<string>>(EC.LengthImageInvalid, ET.LengthImageInvalid);
            }

            var paths = new List<string>();
            foreach (var file in files)
            {
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
                            height = Convert.ToInt32(image.Height * size / (double) image.Width);
                        }
                        else
                        {
                            width = Convert.ToInt32(image.Width * size / (double) image.Height);
                            height = size;
                        }

                        var resized = new Bitmap(width, height);
                        using (var graphics = Graphics.FromImage(resized))
                        {
                            graphics.CompositingQuality = CompositingQuality.HighSpeed;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.CompositingMode = CompositingMode.SourceCopy;
                            graphics.DrawImage(image, 0, 0, width, height);

                            var folderPaths = Path.Combine(_environment.WebRootPath, _settings.Paths.ImagesPostPath,
                                id.ToString());

                            if (!Directory.Exists(folderPaths))
                                Directory.CreateDirectory(folderPaths);

                            var allPath = Path.Combine(folderPaths, file.FileName);

                            using (var output = File.Open(allPath, FileMode.Create))
                            {
                                var qualityParamId = Encoder.Quality;
                                var encoderParameters = new EncoderParameters(1);
                                encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);
                                var codec = ImageCodecInfo.GetImageDecoders()
                                    .FirstOrDefault(x => x.FormatID == ImageFormat.Png.Guid);
                                resized.Save(output, codec, encoderParameters);
                            }

                            var resultPath = Path.Combine(_settings.Paths.ImagesPostPath, id.ToString(), file.FileName);

                            paths.Add(resultPath);

                            postId = 0;

                            await _imageRepository.PostAsync(new PostImage
                            {
                                Name = file.FileName,
                                Path = resultPath,
                                PostId = postId,
                            });
                        }
                    }
                }
            }

            await _unitOfWorks.CommitAsync();

            return Result.OK(paths);
        }

        public async Task<Result<string>> UploadUserImageAsync(UserImageInputModel model)
        {
            if (model?.File == null)
                return Result.Fail<string>(EC.ImageInvalid, ET.ImageInvalid);

            if (model.File.Length > 2_101_156L)
                return Result.Fail<string>(EC.LengthImageInvalid, ET.LengthImageInvalid);

            var user = await _userRepository.GetUserByIdAsync(_userContext.UserId);
            if (user == null)
                return Result.Fail<string>(EC.UserNotFound, ET.UserNotFound);

            var originalImagePath = Path.Combine(_environment.WebRootPath, _settings.Paths.PhotoProfilePath,
                $"{_userContext.UserId}", model.File.Name);

            if (!Directory.Exists(originalImagePath))
                Directory.CreateDirectory(originalImagePath);

            await using (var fileStream = new FileStream(originalImagePath, FileMode.Create))
            {
                await model.File.CopyToAsync(fileStream);
            }

            var userImagePath = Path.Combine(_settings.Paths.PhotoProfilePath, $"{_userContext.UserId}", $"{Guid.NewGuid()}");
            await File.WriteAllBytesAsync(userImagePath, Convert.FromBase64String(model.Cropped));
            
            var position = new NetTopologySuite.Geometries.Point(new Coordinate())
            {
                X = model.X1,
                M = model.X2,
                Y = model.Y1,
                Z = model.Y2
            };

            var userImage = await _userImageRepository.GetUserImageByUserIdAsync(_userContext.UserId);
            if (userImage == null)
            {
                await _userImageRepository.PostAsync(new UserImage
                {
                    UserId = _userContext.UserId,
                    OriginalName = model.File.Name,
                    OriginalImagePath = originalImagePath,
                    ProfileImagePath = userImagePath,
                    Position = new NetTopologySuite.Geometries.Point(new Coordinate()),
                });
            }
            else
            {
                userImage.OriginalImagePath = originalImagePath;
                userImage.ProfileImagePath = userImagePath;
                userImage.Position = position;
                
                _userImageRepository.Put(userImage);
            }
            
            await _unitOfWorks.CommitAsync();

            return Result.OK(userImagePath);
        }
    }
}
