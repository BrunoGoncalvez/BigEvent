using BigEvent.Application.Contracts;
using BigEvent.Application.Services;

using BigEvent.Core.Contracts;

using BigEvent.Data.Repository;
using BigEvent.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.CompilerServices;

namespace BigEvent.API.Services
{
    public static class DependencyInjection
    {

        public static void ResolveDependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDependencyInjections();
            services.AddContextApplication(configuration);
            services.AutoMapperResolve();
        }


        private static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
        }

        private static void AddContextApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("connectionMySQL");
            services.AddDbContext<DataContext>(context => context.UseMySql(connString, ServerVersion.AutoDetect(connString)));
        }

        private static void AutoMapperResolve(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

    }
}