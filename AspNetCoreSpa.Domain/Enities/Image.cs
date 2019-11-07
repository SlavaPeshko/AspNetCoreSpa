using System;
using AspNetCoreSpa.Domain.Enities.Base;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Image : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public bool IsVisible { get; set; }
        public int MyProperty { get; set; }
    }
}
