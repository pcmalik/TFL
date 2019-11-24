using Microsoft.Extensions.DependencyInjection;

namespace RoadStatus
{
    partial class Program
    {
        public static int Main(string[] args)
        {
            // Configure dependencies
            var serviceProvider = DependencyInjection.ConfigureServices();

            // run app
            return serviceProvider.GetService<TFLApplication>().Run(args);
        }
    }
}
