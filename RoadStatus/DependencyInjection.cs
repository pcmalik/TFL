using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoadStatus.Models;
using RoadStatus.Repositories;
using RoadStatus.Repositories.Interfaces;
using RoadStatus.Tracker;
using System;
using System.IO;

namespace RoadStatus
{
    public static class DependencyInjection
    {
        public static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Configuration"));

            // add services
            serviceCollection.AddScoped<IRoadStatusRepository, RoadStatusRepository>();
            serviceCollection.AddScoped<IHttpServiceRepository, HttpServiceRepository>();
            serviceCollection.AddScoped<IStatusTracker, StatusTracker>();

            // add application
            serviceCollection.AddSingleton<TFLApplication>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
