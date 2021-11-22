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

namespace VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomersList
{
    public class GetAgentCustomersListQueryHandler : IRequestHandler<GetAgentCustomersListQuery, Response<IEnumerable<AgentCustomerListVm>>>
    {
        private readonly IAsyncRepository<AgentCustomer> _agentcustomerRepository;
        private readonly IMapper _mapper;

        public GetAgentCustomersListQueryHandler(IMapper mapper, IAsyncRepository<AgentCustomer> agentcustomerRepository)
        {
            _mapper = mapper;
            _agentcustomerRepository = agentcustomerRepository;
        }

        public async Task<Response<IEnumerable<AgentCustomerListVm>>> Handle(GetAgentCustomersListQuery request, CancellationToken cancellationToken)
        {
            var allAgentCustomers = (await _agentcustomerRepository.ListAllAsync()).OrderBy(x => x.AgentCustomerID);
            var agentcustomerlist = _mapper.Map<List<AgentCustomerListVm>>(allAgentCustomers);
            var response = new Response<IEnumerable<AgentCustomerListVm>>(agentcustomerlist);
            return response;
        }
    }
}
