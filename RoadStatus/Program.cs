using Microsoft.Extensions.DependencyInjection;

namespace RoadStatus
{
    partial class Program
    {
        public static int Main(string[] args)
        {
            string roadId = string.Empty;
            if (args != null && args.Length > 0)
                roadId = args[0];

            // Configure dependencies
            var serviceProvider = DependencyInjection.ConfigureServices();

            // run app
            return serviceProvider.GetService<StatusReporter>().GetRoadStatus(roadId);
        }
    }
}
