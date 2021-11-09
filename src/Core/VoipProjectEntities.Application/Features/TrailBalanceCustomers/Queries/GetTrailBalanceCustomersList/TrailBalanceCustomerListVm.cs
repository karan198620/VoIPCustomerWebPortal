using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Queries.GetTrialBalanceCustomerList
{
   public class TrailBalanceCustomerListVm
    {
        public string TrailBalanceCustomerId { get; set; }
        public DateTime Date { get; set; }
        public int TransactionType { get; set; } //enum
    }
}
