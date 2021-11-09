using MediatR;
using System;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<Response<EventDetailVm>>
    {
        public string Id { get; set; }
    }
}
