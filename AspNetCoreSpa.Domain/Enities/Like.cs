using AspNetCoreSpa.Domain.Enities.Base;
using System;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Like : BaseEntity<Guid>
    {
        public bool IsLike { get; set; }

        public Comment Comment { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
