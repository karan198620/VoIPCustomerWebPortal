using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerDetail
{
    public class GetSubscriptionCustomerDetailQuery : IRequest<Response<SubscriptionCustomerDetailVm>>
    {
        public string Id { get; set; }
    }
}
