using System;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Image : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid? PostId { get; set; }
        public Post Post { get; set; }
    }
}
