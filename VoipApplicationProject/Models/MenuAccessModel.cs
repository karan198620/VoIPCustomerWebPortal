using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VoipApplicationProject.Models
{
    public class MenuAccessModel
    {
        public string MenuAccessId { get; set; }
        public bool IsAccess { get; set; }
        public MenuLink MenuLink { get; set; } //enum
        public string CustomerID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string status { get; set; }
        public MenuAccessModel[] data { get; set; }
    }

    public enum MenuLink
    {
        DashboardUsers = 0,
        Billing = 1,
        ManageCallRecording = 2,
        ManageCallHistory = 3,
        ManageSubUser = 4,
        ManageSubscription = 5,
        CallRates = 6,
        DashboardURL = 7,
        Link9 = 8,
        Link10 = 9,
        Link11 = 10,
        DashboardDemoUsers = 11,
        DashboardAdminUsers = 12
    }
}
