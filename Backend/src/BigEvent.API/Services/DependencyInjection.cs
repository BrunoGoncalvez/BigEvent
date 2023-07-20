using BigEvent.Application.Contracts;
using BigEvent.Application.Services;

using BigEvent.Core.Contracts;

using BigEvent.Data.Repository;
using BigEvent.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BigEvent.API.Services
{
    public static class DependencyInjection
    {
        
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
        }

        public static void AddContextApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(context => context.UseSqlServer(configuration.GetConnectionString("connectionString")));
        }

    }
}