using Microsoft.Extensions.DependencyInjection;

namespace RoadStatus
{
    partial class Program
    {
        public static void Main(string[] args)
        {
            // Configure dependencies
            var serviceProvider = DependencyInjection.ConfigureServices();

            // run app
            serviceProvider.GetService<TFLApplication>().Run();
        }
    }
}
