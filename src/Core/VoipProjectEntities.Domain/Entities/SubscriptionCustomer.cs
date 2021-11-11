﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VoipProjectEntities.Domain.Common;

namespace VoipProjectEntities.Domain.Entities
{
    public class SubscriptionCustomer : CommonField
    {
        public Guid SubscriptionCustomerID { get; set; }
        public string CustomerId { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public int SubscriptionType { get; set; }
        public bool ISActive { get; set; }
    }
}
