using System;

namespace VoipProjectEntities.Application.Features.Menu.Commands.CreateMenu
{
    public class CreateMenuDto
    {
        public Guid MenuAccessId { get; set; }
        public bool IsAccess { get; set; }
        public int MenuLink { get; set; } //enum
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
