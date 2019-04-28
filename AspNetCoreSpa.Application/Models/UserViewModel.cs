using System;
using AspNetCoreSpa.Domain.Enities;

namespace AspNetCoreSpa.Application.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public string CountryName { get; set; }
    }

    public static class UserViewModelExtensionMethods
    {
        public static UserViewModel ToEntity(this User user)
        {
            if (user == null) return null;

            return new UserViewModel
            {
                Email = user.Email ?? string.Empty,
                Phone = user.PhoneNumber ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDay = user.DateOfBirth,
                Gender = user.Gender.ToString("G"),
                CountryName = user.Country?.CountryName
            };
        }
    }
}
