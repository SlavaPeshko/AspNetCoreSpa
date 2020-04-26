using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Domain.Entities
{
    public class UserAddress
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public AddressTypeEnum AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }
    }
}