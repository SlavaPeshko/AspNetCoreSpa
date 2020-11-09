using System;
using System.Collections.Generic;

namespace AspNetCoreSpa.Contracts.QueryRepositories.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }

        public List<int> Roles { get; set; }

        public AddressDto Address { get; set; }
        public ImageDto ImageDto { get; set; }
    }
}