using AutoMapper;
using VoipProjectEntities.Application.Features.CallRecordingAgents.Queries.GetCallRecordingAgentsList;
using VoipProjectEntities.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Profiles
{
    public class CallRecordingAgentVmCustomMapper : ITypeConverter<CallRecordingAgent, CallRecordingAgentListVm>
    {
        private readonly IDataProtector _protector;

        public CallRecordingAgentVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }



        public CallRecordingAgentListVm Convert(CallRecordingAgent source, CallRecordingAgentListVm destination, ResolutionContext context)
        {
            CallRecordingAgentListVm dest = new CallRecordingAgentListVm()
            {
                CallRecordingAgentID = _protector.Protect(source.CallRecordingAgentID.ToString()),
                Cost = source.Cost,
                CallStatus = source.CallStatus,
                Country = source.Country

            };
            return dest;

            //throw new NotImplementedException();
        }
    }
}
