using System;
using System.ComponentModel.DataAnnotations;

namespace VoipProjectEntities.Application.Models.Authentication
{
    public class RegistrationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public bool ISMigrated { get; set; }

        [Required]
        public int CustomerTypeID { get; set; } //enum

        [Required]
        public bool ISTrialBalanceOpted { get; set; }

        public string OrganisationName { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
