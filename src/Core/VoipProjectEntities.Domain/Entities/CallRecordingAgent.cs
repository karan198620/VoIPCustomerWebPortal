using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace VoipProjectEntities.Domain.Entities
{
    public class CallRecordingAgent
    {
        [Key]
        public Guid CallRecordingAgentID { get; set; }
        public double Cost { get; set; }
        public DateTime Duration { get; set; }
        public int CallStatus { get; set; }
        public int Country { get; set; }
        public string CustomerId { get; set; }

        [ForeignKey(nameof(AgentCustomer))]
        public Guid? AgentCustomerID { get; set; }
        public AgentCustomer AgentCustomers { get; set; }
    }
}
