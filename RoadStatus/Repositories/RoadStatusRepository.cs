using RoadStatus.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RoadStatus.Models;

namespace RoadStatus.Repositories
{
    public class RoadStatusRepository : IRoadStatusRepository
    {
        public Status[] GetRoadStatus(string roadId)
        {
            throw new NotImplementedException();
        }
    }
}
