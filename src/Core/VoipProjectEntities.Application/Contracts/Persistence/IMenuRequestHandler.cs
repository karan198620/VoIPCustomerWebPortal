using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.Menu.Commands.CreateMenu;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Contracts.Persistence
{
    public interface IMenuRequestHandler
    {
        Task<Response<List<CreateMenuDto>>> Handle(CreateMenuCommand[] request, CancellationToken cancellationToken = default);
    }
}
