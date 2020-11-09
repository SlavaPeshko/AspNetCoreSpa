using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Domain.Entities
{
    public class AddressType : BaseEntity<AddressTypeEnum>
    {
        public AddressType()
        {
            UserAddresses = new HashSet<UserAddress>();
        }

        public string Name { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}