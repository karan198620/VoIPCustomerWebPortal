using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class APILogsModel
    {
        public DateTime Date { get; set; }
        public string APIName { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public string ResponseStatus { get; set; }
        public string status { get; set; }
        public APILogsModel[] data { get; set; }
    }
}
