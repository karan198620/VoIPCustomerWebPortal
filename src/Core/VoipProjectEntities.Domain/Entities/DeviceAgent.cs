using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VoipProjectEntities.Domain.Common;


namespace VoipProjectEntities.Domain.Entities
{
    public class DeviceAgent:CommonField
    {   [Key]
        public Guid DeviceAgentId { get; set; }
        public string MacAddress { get; set; }
        public bool IsWorking { get; set; }
        public int DeviceProfileType { get; set; } //enum
        public Guid DeviceId { get; set; }
        public Guid CustomerId { get; set; }

        [Display(Name = "AgentCustomer")]
        public Guid? AgentCustomerID { get; set; }
        [ForeignKey("AgentCustomerID")]
        public virtual AgentCustomer AgentCustomers { get; set; }
    }
}
