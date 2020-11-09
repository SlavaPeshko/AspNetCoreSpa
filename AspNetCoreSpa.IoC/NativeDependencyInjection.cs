using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Application.Services;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.QueryRepository.Base;
using AspNetCoreSpa.Data.Repositories;
using AspNetCoreSpa.Data.UoW;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using AppContext = AspNetCoreSpa.Application.Services.AppContext;

namespace AspNetCoreSpa.IoC
{
    public static class NativeDependencyInjection
    {
        public static void RegisterServiceCollection(IServiceCollection service)
        {
            // Services/Helpers
            service.AddSingleton<IJwtTokenHelper, JwtTokenHelper>();
            service.AddTransient<IEmailSender, EmailSender>();
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            service.AddSingleton<IUserContext, UserContext>();
            service.AddSingleton<IAppContext, AppContext>();

            // UoW
            service.AddScoped<IUnitOfWorks, UnitOfWorks>();

            // DbContext
            service.AddScoped<ApplicationDbContext>();

            RegisterServices(service, typeof(IBaseService));
            RegisterRepositories(service, typeof(BaseRepository<,>));
            RegisterQueryRepositories(service, typeof(QueryRepositoryBase));

            // Mapper
            var configuration = new MapperConfiguration(cfg =>
            {
                // cfg.CreateMap<CreatePostInputModel, Post>();
                // cfg.CreateMap<Foo, FooDto>();
                // cfg.CreateMap<Bar, BarDto>();
            });
            configuration.AssertConfigurationIsValid();
            var mapper = configuration.CreateMapper();
            service.AddSingleton(mapper);
        }

        private static void RegisterQueryRepositories(IServiceCollection service, Type baseTypeOf)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => !x.IsAbstract && !x.IsInterface
                                          && x.BaseType != null && x.BaseType == baseTypeOf);

            AddScoped(types, service);
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

            var implementedInterfaces = allInterfaces.Except
                (allInterfaces.SelectMany(t => t.GetInterfaces()));

            return implementedInterfaces;
        }

        private static void AddScoped(IEnumerable<Type> types, IServiceCollection service)
        {
            foreach (var type in types)
            foreach (var @interface in GetImplementedInterfaces(type))
                service.AddScoped(@interface, type);
        }
    }
}