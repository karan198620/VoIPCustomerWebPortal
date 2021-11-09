using AutoMapper;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.UpdateCallRecordingAgent
{
    public class UpdateCallRecordingAgentCommandHandler : IRequestHandler<UpdateCallRecordingAgentCommand, Response<Guid>>
    {
        private readonly ICallRecordingAgentRepository _callrecordingagentRepository;
        private readonly IMapper _mapper;
        //private readonly IAgentCustomerRepository _agentcustomerRepository;

        public UpdateCallRecordingAgentCommandHandler(IMapper mapper, ICallRecordingAgentRepository callrecordingagentRepository)
        {
            _mapper = mapper;
            _callrecordingagentRepository = callrecordingagentRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateCallRecordingAgentCommand request, CancellationToken cancellationToken)
        {
            var callrecordingagentToUpdate = await _callrecordingagentRepository.GetByIdAsync(request.CallRecordingAgentID);

            if (callrecordingagentToUpdate == null)
            {
                throw new NotFoundException(nameof(CallRecordingAgent), request.CallRecordingAgentID);
            }

            var validator = new UpdateCallRecordingAgentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, callrecordingagentToUpdate, typeof(UpdateCallRecordingAgentCommand), typeof(CallRecordingAgent));

            await _callrecordingagentRepository.UpdateAsync(callrecordingagentToUpdate);

            return new Response<Guid>(request.CallRecordingAgentID, "Updated successfully ");

            //throw new NotImplementedException();
        }
    }
}
