using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.DeviceAgents.Queries.GetDeviceAgentList;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Profiles
{
   public class DeviceAgentVmCustomMapper : ITypeConverter<DeviceAgent, DeviceAgentListVm>
    {
        private readonly IDataProtector _protector;

        public DeviceAgentVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public DeviceAgentListVm Convert(DeviceAgent source, DeviceAgentListVm destination, ResolutionContext context)
        {
            DeviceAgentListVm dest = new DeviceAgentListVm()
            {
                DeviceAgentId = _protector.Protect(source.DeviceAgentId.ToString()),
                MacAddress = source.MacAddress,
                CreatedAt = source.CreatedAt,
                UpdatedAt= source.UpdatedAt,
                IsWorking=source.IsWorking
            };

            return dest;
        }
    }
}
