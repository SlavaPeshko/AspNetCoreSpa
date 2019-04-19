using System;

namespace AspNetCoreSpa.Application.Models
{
    public class CreateUserInputModel : UserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
    }
}
