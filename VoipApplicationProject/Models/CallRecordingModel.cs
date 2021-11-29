using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class CallRecordingModel
    {
        public string DeviceId { get; set; }
        public string SourceNumber { get; set; }
        public string DesitinationNumber { get; set; }
        public DateTime Time { get; set; }
        public DateTime Date { get; set; }
        public DateTime Duration { get; set; }
        public bool Action { get; set; }
        public string status { get; set; }
        public CallRecordingModel[] data { get; set; }
    }
}
