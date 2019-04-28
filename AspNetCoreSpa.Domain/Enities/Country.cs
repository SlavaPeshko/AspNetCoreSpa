using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Enities.Base;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Country : BaseEntity<Guid>
    {
        public Country()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public string RegioneCode { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
