using Microsoft.Extensions.Options;
using RoadStatus.Models;
using RoadStatus.Repositories.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RoadStatus.Repositories
{
    public class HttpServiceRepository : IHttpServiceRepository
    {
        private readonly IOptions<AppSettings> _config;

        public HttpServiceRepository(IOptions<AppSettings> config)
        {
            if (config == null || config.Value == null)
                throw new ArgumentNullException("config not initialized");

            _config = config;

            if (!ValidConfigurationSettings())
                throw new InvalidOperationException("Api Id or Api key not initialized.");
        }

        private bool ValidConfigurationSettings()
        {
            return !(string.IsNullOrEmpty(_config?.Value.AppId)  || 
                     string.IsNullOrEmpty(_config?.Value.AppKey) ||
                     string.IsNullOrEmpty(_config?.Value.BaseUrl));
        }

        public HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.BaseAddress = new Uri(_config?.Value.BaseUrl);
            return httpClient;
        }

        public string GetQueryString(string query)
        {
            return $"{query}?app_id={_config.Value.AppId}&?app_key={_config.Value.AppKey}";
        }

    }
}
