using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomersList
{
    public class AgentCustomerListVm
    {
        public string AgentCustomerID { get; set; }

        public string AgentName { get; set; }

        public string Password { get; set; }

        public bool ISMigratedAt { get; set; }
    }
}
