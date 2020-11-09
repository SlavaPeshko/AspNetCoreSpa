namespace AspNetCoreSpa.Application.Models.Users
{
    public class CreateUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string InternationalPhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string SecurityCode { get; set; }
    }
}