using VoipProjectEntities.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.UpdateCallRecordingAgent
{
    public class UpdateCallRecordingAgentCommand : IRequest<Response<Guid>>
    {
        public Guid CallRecordingAgentID { get; set; }

        public double Cost { get; set; }

        public DateTime Duration { get; set; }

        public int CallStatus { get; set; }

        public int Country { get; set; }
    }
}
