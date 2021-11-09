using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Commands.DeleteAgentCustomer
{
    public class DeleteAgentCustomerCommand : IRequest
    {
        public string AgentCustomerID { get; set; }
    }
}
