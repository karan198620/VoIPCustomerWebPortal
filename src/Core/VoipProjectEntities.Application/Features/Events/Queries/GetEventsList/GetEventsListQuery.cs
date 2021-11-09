using MediatR;
using System.Collections.Generic;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
