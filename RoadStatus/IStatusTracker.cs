using RoadStatus.Models;
using System.Collections.Generic;
using System.Text;

namespace RoadStatus
{
    public interface IStatusTracker
    {
        RoadInfo GetRoadStatus(string roadId);
    }
}
