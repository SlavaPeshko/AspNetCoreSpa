using System;
using System.Collections.Generic;

namespace AspNetCoreSpa.Contracts.QueryRepositories.Dto
{
    public class PostDto
    {
        public Guid PostId { get; set; }
        public string PostDescription { get; set; }
        public DateTime PostCreateAt { get; set; }
        public DateTime PostUpdateAt { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
