using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerList
{
    public class SubscriptionCustomersListVm
    {
        public string SubscriptionCustomerID { get; set; }
        public string CustomerId { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public int SubscriptionType { get; set; }
        public bool ISActive { get; set; }
    }
}
