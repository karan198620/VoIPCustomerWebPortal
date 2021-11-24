using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class BillingModel
    {
        public int Sr_No { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int Type { get; set; }
        public Double Amount{ get; set; }
        public string TransactionId { get; set; }
        public bool Status { get; set; }
    }
}
