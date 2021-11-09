using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Commands.UpdateDeviceAgent
{
    public class UpdateDeviceAgentCommand : IRequest<Response<Guid>>
    {
        public Guid DeviceAgentId { get; set; }
        public string MacAddress { get; set; }
        public bool IsWorking { get; set; }
        public int DeviceProfileType { get; set; } //enum
        public Guid DeviceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
