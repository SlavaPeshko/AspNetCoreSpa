using System;
using System.Text.Json.Serialization;
using AspNetCoreSpa.Application.Helpers;

namespace AspNetCoreSpa.Application.Models
{
    public class UpdateUserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        [JsonConverter(typeof(IntegerConverter))]
        public int Gender { get; set; }
        public UpdateAddressInputModel Address { get; set; }
    }
}
