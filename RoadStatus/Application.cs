using Microsoft.Extensions.Options;
using RoadStatus.Models;
using RoadStatus.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadStatus
{
    public class TFLApplication
    {
        private readonly IOptions<AppSettings> _config;
        private readonly IRoadStatusRepository _roadStatusRepository;
        private readonly IStatusTracker _statusTracker;

        public TFLApplication(IStatusTracker statusTracker)
        {
            _statusTracker = statusTracker;
        }
        
        internal void Run()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.Write("Input road name and then press 'Enter' key: ");
                var roadName = Console.ReadLine();
                Console.WriteLine();

                var roadStatus = _statusTracker.GetRoadStatus(roadName);

                if (roadStatus.Valid)
                {
                    Console.WriteLine("Road name is: " + roadStatus.DisplayName);
                    Console.WriteLine("Road severity status is: " + roadStatus.StatusSeverity);
                    Console.WriteLine("Road severity status description is: " + roadStatus.StatusSeverityDescription + '\n');
                    Console.WriteLine("LastExitCode is: " + 0 + '\n');
                }
                else
                {
                    Console.WriteLine("Failure status code is: " + roadStatus.FailureStatusCode);
                    Console.WriteLine("Failure message is: " + roadStatus.FailureMessage + '\n');
                    Console.WriteLine("LastExitCode is: " + 1 + '\n');
                }

                Console.Write("Input Y to continue or any other key to exit application: ");
                continueRunning = Console.ReadLine().ToUpper() == "Y";
            }
        }
    }
}
