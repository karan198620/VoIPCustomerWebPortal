using VoipProjectEntities.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Queries.GetCallRecordingAgentsList
{
    public class GetCallRecordingAgentsListQuery : IRequest<Response<IEnumerable<CallRecordingAgentListVm>>>
    {
        public string CustomerId { get; set; }
    }
}
