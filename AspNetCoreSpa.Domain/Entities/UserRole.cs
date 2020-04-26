using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Domain.Entities
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public UserRoleEnum RoleId { get; set; }
        public Role Role { get; set; }
    }
}
