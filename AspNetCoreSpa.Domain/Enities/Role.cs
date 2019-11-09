using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Enities.Base;
using AspNetCoreSpa.Domain.Enities.Enum;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Role : BaseEntity<Guid>
    {
        public Role()
        {
            Users = new HashSet<UserRole>();
        }

        public RoleEnum RoleEnum { get; set; }

        public ICollection<UserRole> Users { get; set; }
    }
}
