using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Queries.GetDeviceAgentList
{
   public  class DeviceAgentListVm
    {
        public string DeviceAgentId { get; set; }
        public string MacAddress { get; set; }
        public bool IsWorking { get; set; }
        public int DeviceProfileType { get; set; } //enum
        public Guid DeviceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
