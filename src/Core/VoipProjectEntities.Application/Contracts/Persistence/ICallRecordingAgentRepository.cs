using VoipProjectEntities.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Contracts.Persistence
{
    public interface ICallRecordingAgentRepository : IAsyncRepository<CallRecordingAgent>
    {
    }
}
