using AspNetCoreSpa.Domain.Enities;

namespace AspNetCoreSpa.Application.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public static class UserViewModelExtensionMethods
    {
        public static UserViewModel ToEntity(this User user)
        {
            if (user == null) return null;

            return new UserViewModel
            {
                Email = user.Email ?? string.Empty,
                Phone = user.Phone ?? string.Empty
            };
        }
    }
}
