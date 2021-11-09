using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Commands.DeleteBalanceCustomer
{
    public class DeleteBalanceCustomerCommand : IRequest
    {
        public string BalanceCustomerID { get; set; }
    }
}
