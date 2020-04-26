using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Role : BaseEntity<UserRoleEnum>
    {
        public Role()
        {
            UsersRoles = new HashSet<UserRole>();
        }

        public string Name { get; set; }
        
        public ICollection<UserRole> UsersRoles { get; set; }

        public ICollection<RoleClaim> RoleClaims { get; set; }
    }
}