using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.Menu.Queries.GetMenu;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.MenuAccesses.Queries.GetMenuAccessList
{
   public class GetMenuListQuery : IRequest<Response<IEnumerable<MenuListVm>>>
    {

    }
}
