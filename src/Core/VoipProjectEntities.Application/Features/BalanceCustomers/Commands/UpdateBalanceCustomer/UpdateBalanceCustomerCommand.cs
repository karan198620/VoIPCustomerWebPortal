using VoipProjectEntities.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Commands.UpdateBalanceCustomer
{
    public class UpdateBalanceCustomerCommand : IRequest<Response<Guid>>
    {
        public Guid BalanceCustomerID { get; set; }

        public double BalanceAmount { get; set; }

        public int TranscationType { get; set; }
    }
}
