using System;

namespace AspNetCoreSpa.Infrastructure.Options
{
    public class GlobalSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Jwt Jwt { get; set; }
        public Paths Paths { get; set; }
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Cache Cache { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public Configurations Configurations { get; set; }
        public TwilioAccountDetails TwilioAccountDetails { get; set; }
        public AzureStorageConnection AzureStorageConnection { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string HangfireConnection { get; set; }
    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Expiration { get; set; }
    }

    public class Paths
    {
        public string PhotoProfilePath { get; set; }
        public string DefaultPhotoProfilePath { get; set; }
        public string DefaultPhotoName { get; set; }
        public string ImagesPostPath { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
    }

    public class Cache
    {
        public TimeSpan CountriesExpiration { get; set; }
    }

    public class EmailSettings
    {
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string SenderName { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
    }

    public class Configurations
    {
        public int AccessFailedCount { get; set; }
        public int ResetTime { get; set; }
    }

    public class TwilioAccountDetails
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string PhoneFrom { get; set; }
    }

    public class AzureStorageConnection
    {
        public string ConnectionString { get; set; }
        public string BlobEndpoint { get; set; }
        public string PathToUserProfile { get; set; }
        public string PathToImagePost { get; set; }
    }
}