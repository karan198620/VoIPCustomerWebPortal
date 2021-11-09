using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerList
{
    public class GetSubscriptionCustomerListQuery : IRequest<Response<IEnumerable<SubscriptionCustomersListVm>>>
    {
    }
}
