using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Commands.CreateAgentCustomer
{
    public class CreateAgentCustomerCommand : IRequest<Response<Guid>>
    {
       // public Guid AgentCustomerID { get; set; }
        public string AgentName { get; set; }
        public string Password { get; set; }
        public bool ISMigratedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CustomerId { get; set; }
        public override string ToString()
        {
            return $" Edited by  Agent name: {AgentName}; Password: {Password}; On: {UpdatedAt.ToShortDateString()};";
        }
    }
}
