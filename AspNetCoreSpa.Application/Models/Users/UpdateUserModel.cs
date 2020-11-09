using System;
using AspNetCoreSpa.Application.Models.Addresses;

namespace AspNetCoreSpa.Application.Models.Users
{
    public class UpdateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int Gender { get; set; }
        public UpdateAddressModel Address { get; set; }
    }
}