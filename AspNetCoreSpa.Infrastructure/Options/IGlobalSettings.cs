namespace AspNetCoreSpa.Infrastructure.Options
{
    public interface IGlobalSettings
    {
        string AllowedHosts { get; set; }
        Cache Cache { get; set; }
        ConnectionStrings ConnectionStrings { get; set; }
        EmailSettings EmailSettings { get; set; }
        Jwt Jwt { get; set; }
        Logging Logging { get; set; }
        Paths Paths { get; set; }
    }
}