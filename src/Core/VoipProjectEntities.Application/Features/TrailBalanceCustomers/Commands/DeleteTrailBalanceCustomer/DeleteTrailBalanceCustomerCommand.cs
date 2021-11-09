using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.DeleteTrialBalanceCustomer
{
   public class DeleteTrailBalanceCustomerCommand : IRequest
    {
        public string TrailBalanceCustomerId { get; set; }
    }
}

