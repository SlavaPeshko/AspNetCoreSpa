using Microsoft.Extensions.DependencyInjection;
using TestClient.Application.Contracts;
using TestClient.Application.Services;
using TestClient.Application.Services.Contracts;
using TestClient.Data.Repositories;
using TestClient.Data.Repositories.Contracts;
using TestClient.Data.UoW;
using TestClinet.Data.Repositories;
using TestClinet.Data.Repositories.Contracts;

namespace TestClient.IoC
{
    public class NativeDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //repositories
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();

            //services
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICountryService, CountryService>();

            //UoW
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        }
    }
}
