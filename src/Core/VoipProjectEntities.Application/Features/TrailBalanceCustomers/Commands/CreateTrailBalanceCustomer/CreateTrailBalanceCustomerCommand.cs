using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.CreateTrialBalanceCustomer
{
   public  class CreateTrailBalanceCustomerCommand : IRequest<Response<Guid>>
    {
        public DateTime Date { get; set; }
        public int TransactionType { get; set; } //enum
    }
}
