using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class TrialBalanceRequestModel
    {
        public string TrailBalanceCustomerId { get; set; }
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; } //enum
        public string CustomerId { get; set; }
        public string Email { get; set; }
        public string OrganisationName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Amount { get; set; }
        public CustomerType CustomerTypeId { get; set; }
        public string status { get; set; }
        public TrialBalanceRequestModel[] data { get; set; }

        [Required(ErrorMessage = "From date cannot be empty")]
        public string FromDate { get; set; }

        [Required(ErrorMessage = "To date cannot be empty")]
        public string ToDate { get; set; }
        public string IsRole { get; set; }
    }

    public enum TransactionType
    {
        debit = 0, credit = 1, contra = 2, reversal = 3
    }
}
