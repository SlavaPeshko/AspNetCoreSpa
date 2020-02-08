using System;

namespace AspNetCoreSpa.Contracts.QueryRepositories.Dto
{
    public class PostDto
    {
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
