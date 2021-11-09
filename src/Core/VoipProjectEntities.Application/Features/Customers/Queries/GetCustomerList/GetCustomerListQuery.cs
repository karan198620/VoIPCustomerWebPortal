using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQuery : IRequest<Response<IEnumerable<CustomerListVm>>>
    {
    }
}
