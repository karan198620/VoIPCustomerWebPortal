using MediatR;
using System;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Menu.Commands.CreateMenu
{
    public class CreateMenuCommand : IRequest<Response<CreateMenuDto>>
    {
        public bool IsAccess { get; set; }
        public int MenuLink { get; set; } //enum
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
