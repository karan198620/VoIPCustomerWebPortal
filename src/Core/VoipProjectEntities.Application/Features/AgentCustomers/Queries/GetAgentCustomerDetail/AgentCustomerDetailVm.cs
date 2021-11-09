using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomerDetail
{
    public class AgentCustomerDetailVm
    {
        public Guid AgentCustomerID { get; set; }

        public string AgentName { get; set; }

        public string Password { get; set; }

        public bool ISMigratedAt { get; set; }
    }
}
