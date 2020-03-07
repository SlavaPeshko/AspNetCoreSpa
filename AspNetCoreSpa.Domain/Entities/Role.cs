using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public Role()
        {
            Users = new HashSet<UserRole>();
        }

        public RoleEnum RoleEnum { get; set; }

        public string RoleName { get; set; }

        public ICollection<UserRole> Users { get; set; }

        public ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
