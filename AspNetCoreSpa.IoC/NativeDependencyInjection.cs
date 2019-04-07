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
using Microsoft.EntityFrameworkCore;

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

            // UoW
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();

            // DbContext
            services.AddScoped<ApplicationDbContext>();
        }
    }
}
