using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Queries.GetDeviceAgentList
{
    public class GetDeviceAgentListQueryHandler : IRequestHandler<GetDeviceAgentListQuery, Response<IEnumerable<DeviceAgentListVm>>>
    {
        private readonly IAsyncRepository<DeviceAgent> _deviceAgentRepository;
        private readonly IMapper _mapper;

        public GetDeviceAgentListQueryHandler(IMapper mapper, IAsyncRepository<DeviceAgent> deviceAgentRepository)
        {
            _mapper = mapper;
            _deviceAgentRepository = deviceAgentRepository;
        }

        public async Task<Response<IEnumerable<DeviceAgentListVm>>> Handle(GetDeviceAgentListQuery request, CancellationToken cancellationToken)
        {
            var allDeviceAgent = (await _deviceAgentRepository.ListAllAsync()).OrderBy(x => x.DeviceAgentId);
            var deviceAgentList = _mapper.Map<List<DeviceAgentListVm>>(allDeviceAgent);
            var response = new Response<IEnumerable<DeviceAgentListVm>>(deviceAgentList);
            return response;
        }
    }
}
