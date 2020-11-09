namespace AspNetCoreSpa.Application.Models.Likes
{
    public class CreateLikeModel
    {
        public bool IsLike { get; set; }
        public int? PostId { get; set; }
    }
}