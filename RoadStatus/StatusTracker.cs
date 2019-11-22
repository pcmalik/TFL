using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RoadStatus.Models;
using RoadStatus.Repositories.Interfaces;
using System;

namespace RoadStatus
{
    public class StatusTracker : IStatusTracker
    {
        private readonly IRoadStatusRepository _roadStatusRepository;
        private readonly IOptions<AppSettings> _config;
        private readonly AppSettings _appSettings;

        public StatusTracker(IRoadStatusRepository roadStatusRepository, IOptions<AppSettings> config)
        {
            _roadStatusRepository = roadStatusRepository ?? throw new ArgumentNullException("roadStatusRepository");
            _config = config ?? throw new ArgumentNullException("config");

            _appSettings = _config?.Value;
        }

        public Status GetRoadStatus(string roadId)
        {
            var status = _roadStatusRepository.GetRoadStatus(roadId);

            if (status != null && status.Length > 0)
                return status[0];
            else
                return null;
        }
    }
}
