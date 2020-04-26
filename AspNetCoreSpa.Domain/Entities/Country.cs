using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Country : BaseEntity<int>
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
        }

        public string Name { get; set; }
        public string RegionCode { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
