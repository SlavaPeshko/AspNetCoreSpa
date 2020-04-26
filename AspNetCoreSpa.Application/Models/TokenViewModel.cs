namespace AspNetCoreSpa.Application.Models
{
    public class TokenViewModel
    {
        public AccessToken AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class AccessToken
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
