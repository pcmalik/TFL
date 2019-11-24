using RoadStatus.Models;

namespace RoadStatus.Tracker
{
    public interface IStatusTracker
    {
        RoadInfo GetRoadStatus(string roadId);
    }
}
