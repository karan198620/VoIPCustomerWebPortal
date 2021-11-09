using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomerDetail
{
    public class BalanceCustomerDetailVm
    {
        public Guid BalanceCustomerID { get; set; }

        public double BalanceAmount { get; set; }

        public int TranscationType { get; set; }
    }
}
