using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Comment : BaseEntity<int>
    {
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}