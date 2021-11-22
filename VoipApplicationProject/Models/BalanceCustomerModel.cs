using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class BalanceCustomerModel
    {
        public string BalanceCustomerID { get; set; }
        public double BalanceAmount { get; set; }
        public TransactionType TranscationType { get; set; }
        public string CustomerId { get; set; }
    }

    public enum TransactionType
    {
        Debit = 0, Credit = 1, Contra = 2, Reversal = 3
    }
}
