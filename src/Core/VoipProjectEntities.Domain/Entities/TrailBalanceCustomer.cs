using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VoipProjectEntities.Domain.Common;

namespace VoipProjectEntities.Domain.Entities
{
    public class TrailBalanceCustomer: CommonField
    {
        #region TrailBalanceCustomer - Lucky

        [Key]
        public Guid TrailBalanceCustomerId { get; set; }
        public DateTime Date { get; set; }
        public int TransactionType { get; set; } //enum
        public string CustomerId { get; set; }

        [ForeignKey(nameof(AgentCustomer))]
        public Guid? AgentCustomerID { get; set; }
        public decimal Amount { get; set; }
        #endregion
    }
}
