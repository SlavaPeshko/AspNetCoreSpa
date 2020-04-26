using System;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Like : BaseEntity<int>
    {
        public bool IsLike { get; set; }
        public Comment Comment { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
