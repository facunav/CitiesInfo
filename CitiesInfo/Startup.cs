using System.Linq;
using System.Reflection;
using AutoMapper;
using BusinessLogic;
using Common.Entities;
using Contracts.Services;
using Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CitiesInfo
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Auto registering dependency injection
            Assembly.Load("BusinessLogic")
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.Name == "I" + t.Name)).ToList()
                .ForEach(t => services.AddTransient(t.GetInterface("I" + t.Name, false), t));

            Assembly.Load("Repositories")
            .GetTypes()
            .Where(t => t.GetInterfaces().Any(i => i.Name == "I" + t.Name)).ToList()
            .ForEach(t => services.AddTransient(t.GetInterface("I" + t.Name, false), t));

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc()
                .AddJsonOptions(o =>
                {
                    if (o.SerializerSettings.ContractResolver != null)
                    {
                        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                        castedResolver.NamingStrategy = null;
                    }
                });
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif            

            //Database connection
            var connectionstring = Configuration["connectionstring:defaultconnectionstring"];

            services.AddDbContext<CitiesInfoContext>(o => o.UseSqlServer(connectionstring, b => b.MigrationsAssembly("CitiesInfo")));

            services.Configure<Email>(Configuration.GetSection("mailSettings"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CitiesInfoContext citiesInfoContext)
        {
            loggerFactory.AddConsole();

            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            citiesInfoContext.EnsureSeedDataForContext();

            //To enable default text-only handlers for common error status codes
            app.UseStatusCodePages();

            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Common.Entities.City, Dtos.City>();
            //    cfg.CreateMap<Dtos.City, Common.Entities.City>();
            //    cfg.CreateMap<ViewModels.CityVm, Common.Entities.City>();
            //    cfg.CreateMap<Common.Entities.City, ViewModels.CityVm>();
            //    cfg.CreateMap<Common.Entities.PointsOfInterest, Dtos.PointsOfInterest>();
            //    cfg.CreateMap<Common.Entities.PointsOfInterest, ViewModels.PointsOfInterestVm>();
            //    cfg.CreateMap<Dtos.PointsOfInterest, Common.Entities.PointsOfInterest>();
            //});

            //Route definition
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Cities}/{action=GetCities}/{id?}");
            });
        }
    }
}
