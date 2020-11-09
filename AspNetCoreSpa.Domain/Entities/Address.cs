using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Address : BaseEntity<int>
    {
        public Address()
        {
            UserAddresses = new HashSet<UserAddress>();
        }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}