using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Commands.CreateDeviceAgent
{
   public class CreateDeviceAgentCommand : IRequest<Response<Guid>>
    {
        public string MacAddress { get; set; }
        public bool IsWorking { get; set; }
        public int DeviceProfileType { get; set; } //enum
        public Guid DeviceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
    }
}
