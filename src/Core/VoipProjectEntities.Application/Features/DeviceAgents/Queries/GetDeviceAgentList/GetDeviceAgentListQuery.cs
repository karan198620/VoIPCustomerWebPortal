using MediatR;
using System.Collections.Generic;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Queries.GetDeviceAgentList
{
   public class GetDeviceAgentListQuery : IRequest<Response<IEnumerable<DeviceAgentListVm>>>
    {
    }
}
