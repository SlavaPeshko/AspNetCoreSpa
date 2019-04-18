using AspNetCoreSpa.Domain.Enities;

namespace AspNetCoreSpa.Application.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string CountryName { get; set; }
        //public string CountryRegioneCode { get; set; }
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
                //ClientName = client.ClientName,
                //UserCode = user.UserCode,
                //CountryName = user.Country.CountryName,
                //CountryRegioneCode = user.Country.CountryRegioneCode
            };
        }
    }
}
