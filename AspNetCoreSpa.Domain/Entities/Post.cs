using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Post : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public User User { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
