using System;

namespace AspNetCoreSpa.Contracts.QueryRepositories.Dto
{
    public class LikeDto
    {
        public int Id { get; set; }
        public bool IsLike { get; set; }
        public int? PostId { get; set; }
        public int UserId { get; set; }
    }
}