using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Menu.Queries.GetMenu
{
    public class GetMenuListQuery : IRequest<Response<IEnumerable<MenuListVm>>>
    {
        public string CustomerId { get; set; }
        public bool IsAccess { get; set; }
    }
}
