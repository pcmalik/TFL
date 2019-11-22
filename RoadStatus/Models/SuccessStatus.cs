using Newtonsoft.Json;

namespace RoadStatus.Models
{
    public class SuccessStatus
    {
        [JsonProperty("$Type")]
        public string Type {get; set;}
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
        public string Bounds { get; set; }
        public string Envelope { get; set; }
        public string Url { get; set; }
    }
}