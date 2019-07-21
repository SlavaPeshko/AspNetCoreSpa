﻿using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.IoC;
using AspNetCoreSpa.WebApi.Filters;
using AspNetCoreSpa.Application.Validators;
using AspNetCoreSpa.Application.Options;
using Newtonsoft.Json.Serialization;
using AspNetCoreSpa.WebApi.Misc;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreSpa.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options => {
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Key = jwtAppSettingOptions[nameof(JwtIssuerOptions.Key)];
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtIssuerOptions:Issuer"],
                    ValidAudience = Configuration["JwtIssuerOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtIssuerOptions:Key"]))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteAdminData", policy => policy.Requirements.Add(new ClaimRequirement("Admin", "Write")));
                options.AddPolicy("CanRemoveAdminData", policy => policy.Requirements.Add(new ClaimRequirement("Admin", "Remove")));
            });

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            //services
            //    .AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //    })
            //    .AddJwtBearer(cfg =>
            //    {
            //        cfg.RequireHttpsMetadata = false;
            //        cfg.SaveToken = true;
            //        cfg.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidIssuer = Configuration["JwtIssuer"],
            //            ValidAudience = Configuration["JwtIssuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
            //            ClockSkew = TimeSpan.Zero // remove delay of token when expire
            //        };
            //    });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            });

            services.AddMvc().AddFluentValidation(fvc =>
                fvc.RegisterValidatorsFromAssemblyContaining<CreateUserModelValidator>());

            RegisterService(services);

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "AspNetCoreSpa", Version = "v1" });
            });
            services
                .AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters(options => options.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddCors(options =>
            {
                options.AddPolicy("CORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if(env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();

            // app.UseIdentityServer();

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                s.RoutePrefix = string.Empty;
            });

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new
                        {
                            context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });

            app.UseCors("CORS");
            app.UseMvc();

            //app.UseMvcWithDefaultRoute();
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
        }

        private static void RegisterService(IServiceCollection service)
        {
            NativeDependencyInjection.RegisterServiceCollection(service);
        }
    }
}
