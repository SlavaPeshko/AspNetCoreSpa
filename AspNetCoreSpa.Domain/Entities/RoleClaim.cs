using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Domain.Entities
{
    public class RoleClaim : BaseEntity<int>
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public UserRoleEnum RoleId { get; set; }
        public Role Role { get; set; }
    }
}
