using RoadStatus.Models;

namespace RoadStatus.Repositories.Interfaces
{
    public interface IRoadStatusRepository
    {
        Road GetRoadStatus(string roadId);
    }
}