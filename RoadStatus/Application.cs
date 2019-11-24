using RoadStatus.Tracker;
using System;

namespace RoadStatus
{
    public class TFLApplication
    {
        private readonly IStatusTracker _statusTracker;

        public TFLApplication(IStatusTracker statusTracker)
        {
            _statusTracker = statusTracker;
        }
        
        public int Run(string[] args)
        {
            int status = 0;
            if (args != null && args.Length > 0)
            {
                string roadId = args[0];

                var roadStatus = _statusTracker.GetRoadStatus(roadId);

                if (roadStatus.Valid)
                {
                    Console.WriteLine($"\nThe status of the {roadId} is as follows\n");
                    Console.WriteLine($"\t Road Status is {roadStatus.StatusSeverity} \n");
                    Console.WriteLine($"\t Road Status Description is {roadStatus.StatusSeverityDescription} \n");
                }
                else
                {
                    Console.WriteLine($"\n{roadId} is not a valid road\n");

                    status = 1;
                }
            }

            return status;
        }
    }
}
