using VoipProjectEntities.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomerDetail
{
    public class GetAgentCustomerDetailQuery : IRequest<Response<AgentCustomerDetailVm>>
    {
        public string Id { get; set; }
    }
}
