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
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
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
}
