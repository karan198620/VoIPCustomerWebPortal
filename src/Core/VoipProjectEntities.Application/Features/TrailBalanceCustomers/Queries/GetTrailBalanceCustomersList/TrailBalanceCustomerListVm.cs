using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.TrailBalanceCustomers.Queries.GetTrailBalanceCustomersList
{
   public class TrailBalanceCustomerListVm
    {
        public string TrailBalanceCustomerId { get; set; }
        public DateTime Date { get; set; }
        public int TransactionType { get; set; } //enum
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
