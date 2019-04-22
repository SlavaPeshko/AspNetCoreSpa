using System;

namespace AspNetCoreSpa.Application.Models
{
    public class CreateUserInputModel : UserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ConfirmationPassword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
