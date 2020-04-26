using System;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Image : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
