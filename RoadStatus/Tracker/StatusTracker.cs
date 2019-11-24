using RoadStatus.Models;
using RoadStatus.Repositories.Interfaces;
using System;

namespace RoadStatus.Tracker
{
    public class StatusTracker : IStatusTracker
    {
        private readonly IRoadStatusRepository _roadStatusRepository;

        public StatusTracker(IRoadStatusRepository roadStatusRepository)
        {
            _roadStatusRepository = roadStatusRepository ?? throw new ArgumentNullException("roadStatusRepository");
        }

        public RoadInfo GetRoadStatus(string roadId)
        {
            return _roadStatusRepository.GetRoadStatus(roadId);
        }
    }
}
