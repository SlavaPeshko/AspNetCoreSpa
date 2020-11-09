using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Models.Users;
using AspNetCoreSpa.Application.Services.AzureBlobStorage;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Infrastructure.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Services
{
    public class FileService : IFileService
    {
        private const long FileLength = 1_048_576L;
        private readonly IWebHostEnvironment _environment;
        private readonly IPostImageRepository _postImageRepository;
        private readonly IPostImageStorageService _postImageStorageService;
        private readonly GlobalSettings _settings;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUserContext _userContext;
        private readonly IUserPhotoQueryRepository _userPhotoQueryRepository;
        private readonly IUserPhotoRepository _userPhotoRepository;
        private readonly IUserPhotoStorageService _userPhotoStorageService;

        private readonly IUserRepository _userRepository;

        public FileService(IUserRepository userRepository,
            IUserPhotoRepository userPhotoRepository,
            IUserContext userContext,
            IWebHostEnvironment environment,
            GlobalSettings settings,
            IUserPhotoStorageService userImageStorageService,
            IPostImageRepository postImageRepository,
            IPostImageStorageService postImageStorageService,
            IUnitOfWorks unitOfWorks,
            IUserPhotoQueryRepository userPhotoQueryRepository)
        {
            _userRepository = userRepository;
            _userPhotoRepository = userPhotoRepository;
            _userContext = userContext;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _settings = settings;
            _userPhotoStorageService = userImageStorageService;
            _postImageRepository = postImageRepository;
            _postImageStorageService = postImageStorageService;
            _unitOfWorks = unitOfWorks;
            _userPhotoQueryRepository = userPhotoQueryRepository;
        }

        public async Task<Result<List<string>>> UploadImagesAsync(int postId, List<IFormFile> files)
        {
            if (files == null)
                return Result.Fail<List<string>>(EC.ImageInvalid, ET.ImageInvalid);

            if (files.Any(file => file.Length > FileLength))
                return Result.Fail<List<string>>(EC.LengthImageInvalid, ET.LengthImageInvalid);

            var images = new List<PostImage>();
            foreach (var file in files)
                images.Add(new PostImage
                {
                    OriginalName = file.FileName,
                    PostId = postId,
                    Path = await _postImageStorageService.UploadFileToBlobAsync(file)
                });

            await _postImageRepository.PostAsync(images);

            await _unitOfWorks.CommitAsync();

            return Result.OK(images.Select(x => x.Path).ToList());
        }

        public async Task<Result<UserPhotoViewModel>> GetUserImageAsync()
        {
            var photo = await _userPhotoQueryRepository.GetUserOriginalPhotoAsync(_userContext.UserId);
            if (photo == null)
                return new Result<UserPhotoViewModel>();

            return Result.OK(new UserPhotoViewModel
            {
                Url = $"{_settings.AzureStorageConnection.BlobEndpoint}{photo.Path}",
                Position = JsonSerializer.Deserialize<PositionModel>(photo.Position)
            });
        }

        public async Task<Result<string>> UploadUserImageAsync(UserImageInputModel model)
        {
            if (model?.File == null)
                return Result.Fail<string>(EC.ImageInvalid, ET.ImageInvalid);

            if (model.File.Length > FileLength)
                return Result.Fail<string>(EC.LengthImageInvalid, ET.LengthImageInvalid);

            var user = await _userRepository.GetUserByIdAsync(_userContext.UserId);
            if (user == null)
                return Result.Fail<string>(EC.UserNotFound, ET.UserNotFound);

            await using (var stream = new MemoryStream(DecodeUrlBase64(model.CroppedImage)))
            {
                await _userPhotoRepository.PostAsync(new UserPhoto
                {
                    UserId = _userContext.UserId,
                    OriginalName = model.File.FileName,
                    Path = await _userPhotoStorageService.UploadFileToBlobAsync(stream, model.File.ContentType)
                });
            }

            var position = JsonSerializer.Serialize(new PositionModel
            {
                X1 = model.X1,
                X2 = model.X2,
                Y1 = model.Y1,
                Y2 = model.Y2
            });

            var path = await _userPhotoStorageService.UploadFileToBlobAsync(model.File);

            var photo = await _userPhotoRepository.GetUserPhotoById(_userContext.UserId);
            if (photo == null)
            {
                await _userPhotoRepository.PostAsync(new UserPhoto
                {
                    UserId = _userContext.UserId,
                    OriginalName = model.File.FileName,
                    Path = path,
                    Position = position
                });
            }
            else
            {
                await _userPhotoStorageService.DeleteBlobDataAsync(photo.Path);

                photo.OriginalName = model.File.FileName;
                photo.Path = path;
                photo.Position = position;

                _userPhotoRepository.Put(photo);
            }

            await _unitOfWorks.CommitAsync();

            return Result.OK(path);
        }

        private static byte[] DecodeUrlBase64(string s)
        {
            var imageParts = s.Split(',').ToList();
            return Convert.FromBase64String(imageParts[1]);
        }
    }
}