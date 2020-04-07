using System;

namespace AspNetCoreSpa.Application.Models
{
    public class UpdateUserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public Guid? CountryId { get; set; }
    }
}
