using VoipProjectEntities.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Queries.GetCalllRecordingAgentDetail
{
    public class GetCallRecordingAgentDetailQuery : IRequest<Response<CallRecordingAgentDetailVm>>
    {
        public string Id { get; set; }
    }
}
