using System;

namespace AspNetCoreSpa.Contracts.QueryRepositories.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderDto Gender { get; set; }
        public Guid? CountryId { get; set; } 
        public CountryDto CountryDto { get; set; }
        
        public ImageDto ImageDto { get; set; }
    }
}
