using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VoipProjectEntities.Domain.Common;

namespace VoipProjectEntities.Domain.Entities
{
    public class AgentCustomer : CommonField
    {
        [Key]
        public Guid AgentCustomerID { get; set; }
        public string AgentName { get; set; }
        public string Password { get; set; }
        public bool ISMigratedAt { get; set; }
        public string CustomerId { get; set; }
    }
}
