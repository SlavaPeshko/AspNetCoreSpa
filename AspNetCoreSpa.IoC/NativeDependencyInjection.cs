using Microsoft.Extensions.DependencyInjection;
using AspNetCoreSpa.Application.Contracts;
using AspNetCoreSpa.Application.Services;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Data.Repositories;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using TestClinet.Data.Repositories;
using TestClinet.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Application.Helpers;

namespace AspNetCoreSpa.IoC
{
    public class NativeDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICountryService, CountryService>();

            // Services/Helpers
            services.AddSingleton<IJwtTokenHelper, JwtTokenHelper>();

            // UoW
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();

            // DbContext
            services.AddScoped<ApplicationDbContext>();
        }
    }
}
