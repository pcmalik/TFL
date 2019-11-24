using RoadStatus.Models;

namespace RoadStatus
{
    public interface IStatusTracker
    {
        RoadInfo GetRoadStatus(string roadId);
    }
}
