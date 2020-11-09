namespace AspNetCoreSpa.Application.Models.Users
{
    public class EmailTokenModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
    }
}