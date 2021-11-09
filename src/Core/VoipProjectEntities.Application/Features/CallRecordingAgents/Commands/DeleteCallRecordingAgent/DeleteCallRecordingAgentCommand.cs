using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.DeleteCallRecordingAgent
{
    public class DeleteCallRecordingAgentCommand : IRequest
    {
        public string CallRecordingAgentID { get; set; }
    }
}
