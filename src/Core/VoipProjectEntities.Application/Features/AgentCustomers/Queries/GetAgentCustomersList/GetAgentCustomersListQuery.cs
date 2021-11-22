using VoipProjectEntities.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomersList
{
    public class GetAgentCustomersListQuery : IRequest<Response<IEnumerable<AgentCustomerListVm>>>
    {
        //public string Customerid { get; set; }
    }
}
