using System;
using AspNetCoreSpa.Domain.Enities.Base;

namespace AspNetCoreSpa.Domain.Enities
{
    public class RoleClaim : BaseEntity<Guid>
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public Guid RoleId { get; set; }
    }
}
