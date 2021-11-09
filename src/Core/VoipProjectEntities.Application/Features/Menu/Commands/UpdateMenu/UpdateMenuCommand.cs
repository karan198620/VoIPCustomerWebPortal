using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.MenuAccesses.Commands.UpdateMenuAccess
{
    public class UpdateMenuCommand : IRequest<Response<Guid>>
    {
        public Guid MenuAccessId { get; set; }
        public bool IsAccess { get; set; }
        public int MenuLink { get; set; } //enum
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
