namespace AspNetCoreSpa.Application.Models
{
    public class UpdatePasswordInputModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}