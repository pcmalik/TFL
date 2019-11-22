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

        public TFLApplication(IRoadStatusRepository roadStatusRepository, IOptions<AppSettings> config)
        {
            _roadStatusRepository = roadStatusRepository ?? throw new ArgumentNullException("roadStatusRepository");
            _config = config ?? throw new ArgumentNullException("config");
        }
        
        internal void Run()
        {
            IStatusTracker statusTracker = new StatusTracker(_roadStatusRepository, _config);
        }
    }
}
