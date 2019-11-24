using System.Net.Http;
using System.Threading.Tasks;

namespace RoadStatus.Repositories.Interfaces
{
    public interface IHttpServiceRepository
    {
        HttpClient GetHttpClient();
        string GetQueryString(string query);
    }
}
