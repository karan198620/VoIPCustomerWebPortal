using AutoMapper;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomerDetail
{
    public class GetAgentCustomerDetailQueryHandler : IRequestHandler<GetAgentCustomerDetailQuery, Response<AgentCustomerDetailVm>>
    {
        private readonly IAsyncRepository<AgentCustomer> _agentcustomerRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;


        private readonly IDataProtector _protector;
        public GetAgentCustomerDetailQueryHandler(IMapper mapper, IAsyncRepository<AgentCustomer> agentcustomerRepository, IAsyncRepository<Category> categoryRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _agentcustomerRepository = agentcustomerRepository;
            _categoryRepository = categoryRepository;
            _protector = provider.CreateProtector("");
        }


        public async Task<Response<AgentCustomerDetailVm>> Handle(GetAgentCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            string id = _protector.Unprotect(request.Id);

            var @event = await _agentcustomerRepository.GetByIdAsync(new Guid(id));
            var agentcustomerDetailDto = _mapper.Map<AgentCustomerDetailVm>(@event);

           

            var response = new Response<AgentCustomerDetailVm>(agentcustomerDetailDto);
            return response;
            //throw new NotImplementedException();
        }
    }
}
