using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Enities.Base;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Role : BaseEntity<Guid>
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
