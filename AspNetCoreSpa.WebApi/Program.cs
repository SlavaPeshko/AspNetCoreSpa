using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AspNetCoreSpa.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                IHostingEnvironment env = hostingContext.HostingEnvironment;

                config.SetBasePath(Directory.GetCurrentDirectory());
                //config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            }).UseStartup<Startup>();
    }
}
