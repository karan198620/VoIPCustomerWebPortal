using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class UserLogsModel
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string EmailID { get; set; }
        public string LoggedInTime { get; set; }
        public string LoggedOutTime { get; set; }
        public string Country { get; set; }
        public string IP { get; set; }
        public string Device { get; set; }
        public string status { get; set; }
        public UserLogsModel[] data { get; set; }
    }
}
