using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Likes;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;

namespace AspNetCoreSpa.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeQueryRepository _likeQueryRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IPostQueryRepository _postQueryRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUserContext _userContext;
        private readonly IUserQueryRepository _userQueryRepository;


        public LikeService(ILikeRepository likeRepository,
            ILikeQueryRepository likeQueryRepository,
            IUserContext userContext,
            IUserQueryRepository userQueryRepository,
            IPostQueryRepository postQueryRepository,
            IUnitOfWorks unitOfWorks)
        {
            _likeRepository = likeRepository;
            _likeQueryRepository = likeQueryRepository;
            _userContext = userContext;
            _userQueryRepository = userQueryRepository;
            _postQueryRepository = postQueryRepository;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Result> DeleteLikeByIdAsync(int id)
        {
            var like = await _likeRepository.GetLikeByIdAsync(id);
            if (like == null)
                return Result.Fail(EC.LikeNotFound, ET.LikeNotFound);

            _likeRepository.Delete(like);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<int> GetRatingByPostIdAsync(int postId)
        {
            return await _likeQueryRepository.GetRatingByPostIdAsync(postId);
        }

        public async Task<Result<LikeViewModel>> CreateLikePostAsync(int? postId, bool isLike)
        {
            if (_userContext.UserId == -1 || !await _userQueryRepository.IsExistUserAsync(_userContext.UserId))
                return Result.Fail<LikeViewModel>(EC.UserNotFound, ET.UserNotFound);

            if (!postId.HasValue || !await _postQueryRepository.IsExistPostAsync(postId.Value))
                return Result.Fail<LikeViewModel>(EC.PostNotFound, ET.PostNotFound);

            var like = new Like
            {
                IsLike = isLike,
                UserId = _userContext.UserId,
                PostId = postId
            };

            await _likeRepository.PostAsync(like);
            await _unitOfWorks.CommitAsync();

            var model = new LikeViewModel
            {
                Id = like.Id,
                IsLike = isLike,
                PostId = postId,
                UserId = _userContext.UserId
            };

            return Result.OK(model);
        }
    }
}