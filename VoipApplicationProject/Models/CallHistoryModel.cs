using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class CallHistoryModel
    {
        public DateTime Date { get; set; }
        public DateTime Hours { get; set; }
        public string  MobileNumber { get; set; }
        public  int  Duration { get; set; }
        public string  SourceName { get; set; }
        public string SourceNumber { get; set; }
        public double Cost { get; set; }
        public bool CallStatus { get; set; }
        public string status { get; set; }
        public CallRecordingModel[] data { get; set; }
    }
}
