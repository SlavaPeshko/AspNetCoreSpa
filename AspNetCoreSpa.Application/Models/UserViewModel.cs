using AspNetCoreSpa.Domain.Enities;

namespace AspNetCoreSpa.Application.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string CountryName { get; set; }
        public string CountryRegioneCode { get; set; }
    }

    public static class UserViewModelExtensionMethods
    {
        public static UserViewModel ToEntity(this User user)
        {
            if (user == null || user.Country == null) return null;

            return new UserViewModel
            {
                //ClientName = client.ClientName,
                UserCode = user.UserCode,
                CountryName = user.Country.CountryName,
                CountryRegioneCode = user.Country.CountryRegioneCode
            };
        }
    }
}
