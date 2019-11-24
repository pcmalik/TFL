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
                    Console.WriteLine("Road name is: " + roadStatus.DisplayName);
                    Console.WriteLine("Road severity status is: " + roadStatus.StatusSeverity);
                    Console.WriteLine("Road severity status description is: " + roadStatus.StatusSeverityDescription + '\n');
                }
                else
                {
                    Console.WriteLine("Failure status code is: " + roadStatus.FailureStatusCode);
                    Console.WriteLine("Failure message is: " + roadStatus.FailureMessage + '\n');

                    status = 1;
                }
            }

            /*Unocomment below line if you need to see the output in console*/
            //Console.ReadLine();

            return status;
        }
    }
}
