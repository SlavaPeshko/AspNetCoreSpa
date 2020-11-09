using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Application.Models.Likes
{
    public class LikeViewModel
    {
        public int Id { get; set; }
        public bool IsLike { get; set; }
        public int? PostId { get; set; }
        public int UserId { get; set; }
    }

    public static class LikeViewModelExtensionMethods
    {
        public static LikeViewModel ToViewModel(this LikeDto like)
        {
            if (like == null) return null;

            return new LikeViewModel
            {
                Id = like.Id,
                IsLike = like.IsLike,
                PostId = like.PostId,
                UserId = like.UserId
            };
        }
    }
}