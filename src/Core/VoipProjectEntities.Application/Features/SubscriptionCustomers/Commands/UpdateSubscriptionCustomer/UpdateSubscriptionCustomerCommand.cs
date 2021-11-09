using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.UpdateSubscriptionCustomer
{
   public  class UpdateSubscriptionCustomerCommand : IRequest<Response<Guid>>
    {
        public Guid SubscriptionCustomerID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public int SubscriptionType { get; set; }
        public bool ISActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
