using Microsoft.Extensions.DependencyInjection;
using AspNetCoreSpa.Data.Repositories;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Application.Helpers;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity.UI.Services;
using AspNetCoreSpa.Application.Services.Contracts;

namespace AspNetCoreSpa.IoC
{
    public class NativeDependencyInjection
    {
        public static void RegisterServiceCollection(IServiceCollection service)
        {
            // Services/Helpers
            service.AddSingleton<IJwtTokenHelper, JwtTokenHelper>();
            service.AddTransient<IEmailSender, EmailSender>();

            // UoW
            service.AddScoped<IUnitOfWorks, UnitOfWorks>();

            // DbContext
            service.AddScoped<ApplicationDbContext>();

            RegisterServices(service, typeof(IBaseService));
            RegisterRepositories(service, typeof(BaseRepository<,>));
        }

        private static void RegisterRepositories(IServiceCollection service, Type baseTypeOf)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsAbstract && !x.IsInterface && x.BaseType != null 
                    && x.BaseType.IsGenericType && x.BaseType.GetGenericTypeDefinition() == baseTypeOf);

            AddScoped(types, service);
        }

        private static void RegisterServices(IServiceCollection service, Type baseTypeOf)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => baseTypeOf.IsAssignableFrom(x) && x.IsClass);

            AddScoped(types, service);
        }

        private static IEnumerable<Type> GetImplementedInterfaces(Type type)
        {
            var allInterfaces = type.GetInterfaces();

            var implementedlInterfaces = allInterfaces.Except
                    (allInterfaces.SelectMany(t => t.GetInterfaces()));

            return implementedlInterfaces;
        }

        private static void AddScoped(IEnumerable<Type> types, IServiceCollection service)
        {
            foreach (var type in types)
            {
                foreach (var @interface in GetImplementedInterfaces(type))
                {
                    service.AddScoped(@interface, type);
                }
            }
        }
    }
}
