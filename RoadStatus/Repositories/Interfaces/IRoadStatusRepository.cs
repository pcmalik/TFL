using RoadStatus.Models;

namespace RoadStatus.Repositories.Interfaces
{
    public interface IRoadStatusRepository
    {
        Status[] GetRoadStatus(string roadId);
    }
}