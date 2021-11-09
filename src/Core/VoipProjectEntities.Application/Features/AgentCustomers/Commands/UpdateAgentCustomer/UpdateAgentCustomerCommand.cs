using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Commands.UpdateAgentCustomer
{
    public class UpdateAgentCustomerCommand : IRequest<Response<Guid>>
    {
        public Guid AgentCustomerID { get; set; }

        public string AgentName { get; set; }

        public string Password { get; set; }

        public bool ISMigratedAt { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
