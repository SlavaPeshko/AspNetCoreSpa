using System;
using AspNetCoreSpa.Domain.Enities.Base;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Image : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Guid UserXref { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
