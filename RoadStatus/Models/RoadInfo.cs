using System;
using System.Collections.Generic;
using System.Text;

namespace RoadStatus.Models
{

    public class RoadInfo
    {
        public bool Valid { get; set; }

        public string DisplayName { get; set; }
        public string StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
        public string FailureMessage { get; set; }
    }

}
