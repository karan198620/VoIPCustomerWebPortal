using AutoMapper;
using VoipProjectEntities.Application.Contracts.Infrastructure;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.CreateCallRecordingAgent
{
    public class CreateCallRecordingAgentCommandHandler : IRequestHandler<CreateCallRecordingAgentCommand, Response<Guid>>
    {
        private readonly ICallRecordingAgentRepository _callrecordingagentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateCallRecordingAgentCommandHandler> _logger;


        public CreateCallRecordingAgentCommandHandler(IMapper mapper, ICallRecordingAgentRepository callrecordingagentRepository, IEmailService emailService, ILogger<CreateCallRecordingAgentCommandHandler> logger)
        {
            _mapper = mapper;
            _callrecordingagentRepository = callrecordingagentRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Response<Guid>> Handle(CreateCallRecordingAgentCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var validator = new CreateCallRecordingAgentCommandValidator(_callrecordingagentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<CallRecordingAgent>(request);

            @event = await _callrecordingagentRepository.AddAsync(@event);

            var response = new Response<Guid>(@event.CallRecordingAgentID, "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;

        }
    }
}
