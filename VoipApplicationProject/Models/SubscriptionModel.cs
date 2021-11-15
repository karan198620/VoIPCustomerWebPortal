using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class SubscriptionModel
    {
        public string SubscriptionCustomerID { get; set; }
        public string CustomerId { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public int SubscriptionType { get; set; }
        public bool ISActive { get; set; }
    }
    public enum SubscriptionType
    {
        Plan1 = 0,
        Plan2 = 1,
        Plan3 = 2
    }
}
