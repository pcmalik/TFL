using RoadStatus.Repositories.Interfaces;
using System;
using RoadStatus.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace RoadStatus.Repositories
{
    public class RoadStatusRepository : IRoadStatusRepository
    {
        private readonly IHttpServiceRepository _httpServiceRepository;

        public RoadStatusRepository(IHttpServiceRepository httpServiceRepository)
        {
            _httpServiceRepository = httpServiceRepository ?? throw new ArgumentNullException("httpServiceRepository");
        }

        public RoadInfo GetRoadStatus(string roadId)
        {
            var roadInfo = new RoadInfo();
            var httpClient = _httpServiceRepository.GetHttpClient();
            string query = _httpServiceRepository.GetQueryString($"Road/{roadId}");
            string responseString = string.Empty;

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(query).Result;

                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    var successStatus = JsonConvert.DeserializeObject<SuccessStatus[]>(responseString);

                    if (successStatus != null && successStatus.Length > 0)
                    {
                        roadInfo.DisplayName = successStatus[0].DisplayName;
                        roadInfo.StatusSeverity = successStatus[0].StatusSeverity;
                        roadInfo.StatusSeverityDescription = successStatus[0].StatusSeverityDescription;
                    }
                    roadInfo.Valid = true;
                }
                else
                {

                    responseString = response.Content.ReadAsStringAsync().Result;
                    var failureStatus = JsonConvert.DeserializeObject<FailureStatus>(responseString);
                    if (failureStatus != null)
                        roadInfo.FailureMessage = $"{roadId} is not a valid road";

                    roadInfo.Valid = false;
                }
            }
            catch (Exception ex)
            {
                roadInfo.Valid = false;

                //value in 'responseString' will be available when there is deserializatoin error due to unexpected response from server 
                //eg: for invalid authentication keys
                if (!string.IsNullOrEmpty(responseString))
                    roadInfo.FailureMessage = responseString;
                else
                    roadInfo.FailureMessage = ex.Message + '\n' + ex.StackTrace;
            }

            return roadInfo;
        }
    }
}
