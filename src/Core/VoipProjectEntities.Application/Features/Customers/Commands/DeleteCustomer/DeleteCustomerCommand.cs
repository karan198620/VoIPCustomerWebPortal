using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public string Id { get; set; }
    }
}
