namespace AspNetCoreSpa.Application.Models
{
    public class LogInViewModel
    {
        public AccessToken AccessToken { get; set; }
        public string RerfreshToken { get; set; }
    }

    public class AccessToken
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
