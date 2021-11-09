using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.Menu.Queries.GetMenu
{
    public class MenuListVm
    {
        public string MenuAccessId { get; set; }
        public bool IsAccess { get; set; }
        public int MenuLink { get; set; } //enum
        public string CustomerID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
