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
            UserRoles = new HashSet<UserRole>();
        }

        public RoleEnum Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
