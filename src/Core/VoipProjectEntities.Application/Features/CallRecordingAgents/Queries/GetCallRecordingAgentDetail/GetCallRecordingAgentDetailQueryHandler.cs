using AutoMapper;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Queries.GetCalllRecordingAgentDetail
{
    public class GetCallRecordingAgentDetailQueryHandler : IRequestHandler<GetCallRecordingAgentDetailQuery, Response<CallRecordingAgentDetailVm>>
    {
        private readonly IAsyncRepository<CallRecordingAgent> _callrecordingagentRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;


        private readonly IDataProtector _protector;
        public GetCallRecordingAgentDetailQueryHandler(IMapper mapper, IAsyncRepository<CallRecordingAgent> callrecordingagentRepository, IAsyncRepository<Category> categoryRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _callrecordingagentRepository = callrecordingagentRepository;
            _categoryRepository = categoryRepository;
            _protector = provider.CreateProtector("");
        }


        public async Task<Response<CallRecordingAgentDetailVm>> Handle(GetCallRecordingAgentDetailQuery request, CancellationToken cancellationToken)
        {
            string id = _protector.Unprotect(request.Id);

            var @event = await _callrecordingagentRepository.GetByIdAsync(new Guid(id));
            var callrecordingagentDetailDto = _mapper.Map<CallRecordingAgentDetailVm>(@event);



            var response = new Response<CallRecordingAgentDetailVm>(callrecordingagentDetailDto);
            return response;
            //throw new NotImplementedException();
        }
    }
}
