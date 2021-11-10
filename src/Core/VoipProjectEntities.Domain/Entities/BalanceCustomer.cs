using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace VoipProjectEntities.Domain.Entities
{
    public class BalanceCustomer
    {
        [Key]
        public Guid BalanceCustomerID { get; set; }
        public double BalanceAmount { get; set; }
        public int TranscationType { get; set; }
        public Guid CustomerId { get; set; }
    }
}
