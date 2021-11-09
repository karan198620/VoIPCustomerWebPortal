using AutoMapper;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Queries.GetCallRecordingAgentsList
{
    public class GetCallRecordingAgentsListQueryHandler : IRequestHandler<GetCallRecordingAgentsListQuery, Response<IEnumerable<CallRecordingAgentListVm>>>
    {
        private readonly IAsyncRepository<CallRecordingAgent> _callrecordingagentRepository;
        private readonly IMapper _mapper;

        public GetCallRecordingAgentsListQueryHandler(IMapper mapper, IAsyncRepository<CallRecordingAgent> callrecordingagentRepository)
        {
            _mapper = mapper;
            _callrecordingagentRepository = callrecordingagentRepository;
        }

        public async Task<Response<IEnumerable<CallRecordingAgentListVm>>> Handle(GetCallRecordingAgentsListQuery request, CancellationToken cancellationToken)
        {
            var allcallRecordingAgent = (await _callrecordingagentRepository.ListAllAsync()).OrderBy(x => x.CustomerId);
            var callrecordingagentlist = _mapper.Map<List<CallRecordingAgentListVm>>(allcallRecordingAgent);
            var response = new Response<IEnumerable<CallRecordingAgentListVm>>(callrecordingagentlist);
            return response;
        }
    }
}
