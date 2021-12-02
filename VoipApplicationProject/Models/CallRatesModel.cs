using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class CallRatesModel
    {
        public Country Country { get; set; }
        public double Callrates { get; set; }
    }
    public enum Country
    {
        India = 0,
        Pakistan = 1,
        Srilanka = 2,
        Brazil = 3,
        China = 4,
        Japan = 5,
        Afghanistan = 6,
        Russia = 7,
        Nepal = 8
    }
}
