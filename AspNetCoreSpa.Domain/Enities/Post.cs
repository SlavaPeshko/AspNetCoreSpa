using AspNetCoreSpa.Domain.Enities.Base;
using System;
using System.Collections.Generic;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Post : BaseEntity<Guid>
    {
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
