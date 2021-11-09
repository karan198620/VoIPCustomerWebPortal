using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerDetail
{
   public  class SubscriptionCustomerDetailVm
    {
        public Guid SubscriptionCustomerID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public int SubscriptionType { get; set; }
        public bool ISActive { get; set; }
    }
}
