using RoadStatus.Models;
using System.Collections.Generic;
using System.Text;

namespace RoadStatus
{
    public interface IStatusTracker
    {
        Status GetRoadStatus(string roadId);
    }
}
