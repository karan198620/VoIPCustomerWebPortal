using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoipProjectEntities.Domain.Entities
{
    public class TrailBalanceCustomer
    {
        [Key]
        public Guid TrailBalanceCustomerId { get; set; }
        public DateTime Date { get; set; }
        public int TransactionType { get; set; } //enum
        [Display(Name = "Customer")]
        public Guid? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customers { get; set; }
    }
}
