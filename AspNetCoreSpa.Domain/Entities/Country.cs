using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Country : BaseEntity<Guid>
    {
        public Country()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public string RegionCode { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
