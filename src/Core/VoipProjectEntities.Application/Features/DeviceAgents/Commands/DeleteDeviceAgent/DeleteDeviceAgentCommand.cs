using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Commands.DeleteDeviceAgent
{
    public class DeleteDeviceAgentCommand : IRequest
    {
       public string DeviceAgentId { get; set; }
    }
}
