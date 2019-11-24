using RoadStatus.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RoadStatus.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace RoadStatus.Repositories
{
    public class RoadStatusRepository : IRoadStatusRepository
    {
        private readonly IHttpServiceRepository _httpServiceRepository;

        public RoadStatusRepository(IHttpServiceRepository httpServiceRepository)
        {
            _httpServiceRepository = httpServiceRepository;
        }

        public RoadInfo GetRoadStatus(string roadId)
        {
            var roadInfo = new RoadInfo();
            var httpClient = _httpServiceRepository.GetHttpClient();
            string query = _httpServiceRepository.GetQueryString($"Road/{roadId}");
            HttpResponseMessage response = httpClient.GetAsync(query).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                var successStatus = JsonConvert.DeserializeObject<SuccessStatus[]>(responseString);

                if (successStatus != null && successStatus.Length > 0)
                {
                    roadInfo.Valid = true;
                    roadInfo.DisplayName = successStatus[0].DisplayName;
                    roadInfo.StatusSeverity = successStatus[0].StatusSeverity;
                    roadInfo.StatusSeverityDescription = successStatus[0].StatusSeverityDescription;
                }
            }
            else
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                var failureStatus = JsonConvert.DeserializeObject<FailureStatus>(responseString);

                if (failureStatus != null)
                {
                    roadInfo.Valid = false;
                    roadInfo.FailureStatusCode = failureStatus.HttpStatusCode;
                    roadInfo.FailureMessage = failureStatus.Message;
                }
            }

            return roadInfo;
        }
    }
}
