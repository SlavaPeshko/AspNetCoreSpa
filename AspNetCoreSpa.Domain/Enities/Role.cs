using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Enities.Base;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Role : BaseEntity<Guid>
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
