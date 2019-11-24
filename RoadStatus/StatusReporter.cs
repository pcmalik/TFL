using RoadStatus.Tracker;
using System;

namespace RoadStatus
{
    public class StatusReporter
    {
        private readonly IStatusTracker _statusTracker;

        public StatusReporter(IStatusTracker statusTracker)
        {
            _statusTracker = statusTracker;
        }
        
        public int GetRoadStatus(string roadId)
        {
            int status = 1;
            if (!string.IsNullOrEmpty(roadId))
            {
                var roadStatus = _statusTracker.GetRoadStatus(roadId);

                if (roadStatus.Valid)
                {
                    Console.WriteLine($"\nThe status of the {roadId} is as follows\n");
                    Console.WriteLine($"\t Road Status is {roadStatus.StatusSeverity} \n");
                    Console.WriteLine($"\t Road Status Description is {roadStatus.StatusSeverityDescription} \n");
                    status = 0;
                }
                else
                {
                    Console.WriteLine($"\n{ roadStatus.FailureMessage}\n");
                }
            }

            return status;
        }
    }
}
