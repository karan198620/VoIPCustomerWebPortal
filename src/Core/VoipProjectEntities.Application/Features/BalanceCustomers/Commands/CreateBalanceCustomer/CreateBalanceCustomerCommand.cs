using VoipProjectEntities.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Commands.CreateBalanceCustomer
{
    public class CreateBalanceCustomerCommand : IRequest<Response<Guid>>
    {
        public double BalanceAmount { get; set; }

        public int TranscationType { get; set; }
    }
}
