using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.DeleteSubscriptionCustomer
{
    public class DeleteSubscriptionCustomerCommand : IRequest
    {
        public string SubscriptionCustomerID { get; set; }
    }
}
