using Microsoft.Extensions.DependencyInjection;
using TestClient.Application.Services;
using TestClient.Application.Services.Contracts;
using TestClient.Data.Repositories;
using TestClient.Data.Repositories.Contracts;
using TestClient.Data.UoW;

namespace TestClient.IoC
{
    public class NativeDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //repositories
            services.AddScoped<IClientRepository, ClientRepository>();

            //services
            services.AddScoped<IClientService, ClientService>();

            //UoW
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        }
    }
}
