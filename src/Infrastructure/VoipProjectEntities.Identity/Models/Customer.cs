using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace VoipProjectEntities.Identity.Models
{
    public class Customer : IdentityUser
    {
        public string CustomerName { get; set; }
        public bool ISMigrated { get; set; }
        public int CustomerTypeID { get; set; } //enum
        public bool ISTrialBalanceOpted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
