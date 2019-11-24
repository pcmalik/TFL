using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoadStatus.Models;
using RoadStatus.Repositories;
using RoadStatus.Repositories.Interfaces;
using System;
using System.IO;

namespace RoadStatus
{
    partial class Program
    {
        public static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // run app
            serviceProvider.GetService<TFLApplication>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
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
            serviceCollection.AddScoped<TFLApplication>();
        }

    }
}
