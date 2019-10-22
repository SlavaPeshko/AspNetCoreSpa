using AspNetCoreSpa.Domain.Enities.Base;
using System;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Photo : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}
