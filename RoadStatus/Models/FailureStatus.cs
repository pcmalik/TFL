using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadStatus.Models
{
    public class FailureStatus
    {
        [JsonProperty("$Type")]
        public string Type { get; set; }
        public string TimestampUtc { get; set; }
        public string ExceptionType { get; set; }
        public string HttpStatusCode { get; set; }
        public string HttpStatus { get; set; }
        public string RelativeUri { get; set; }
        public string Message { get; set; }
    }
}
