using AspNetCoreSpa.Domain.Enities.Base;
using System;
using System.Collections.Generic;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Comment : BaseEntity<Guid>
    {
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
