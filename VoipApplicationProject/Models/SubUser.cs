using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class SubUser
    {
        public int SrNo { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CalledID { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public SubUserType SubUserTypeID { get; set; }


    }
    public enum SubUserType
    {
        Agent = 0,
        Device = 1,
    }
}
