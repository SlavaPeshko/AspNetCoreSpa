using System;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class RoleClaim : BaseEntity<Guid>
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
