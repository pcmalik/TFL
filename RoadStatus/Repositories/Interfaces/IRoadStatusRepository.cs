using Microsoft.Extensions.Options;
using RoadStatus.Models;
using System.Threading.Tasks;

namespace RoadStatus.Repositories.Interfaces
{
    public interface IRoadStatusRepository
    {
        RoadInfo GetRoadStatus(string roadId);
    }
}