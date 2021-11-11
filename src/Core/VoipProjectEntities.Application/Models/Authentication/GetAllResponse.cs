using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Models.Authentication
{
    public class GetAllResponse
    {
        public string CustomerName { get; set; }
        public bool ISMigrated { get; set; }
        public int CustomerTypeID { get; set; } //enum
        public bool ISTrialBalanceOpted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
