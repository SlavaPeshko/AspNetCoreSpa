using System;

namespace AspNetCoreSpa.Application.Models
{
    public class UpdateUserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
    }
}
