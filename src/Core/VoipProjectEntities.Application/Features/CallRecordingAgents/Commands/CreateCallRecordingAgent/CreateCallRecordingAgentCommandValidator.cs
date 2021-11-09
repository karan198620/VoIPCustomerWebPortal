using VoipProjectEntities.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.CreateCallRecordingAgent
{
    public class CreateCallRecordingAgentCommandValidator : AbstractValidator<CreateCallRecordingAgentCommand>
    {
        private readonly ICallRecordingAgentRepository _callrecordingagentRepository;


        public CreateCallRecordingAgentCommandValidator(ICallRecordingAgentRepository callrecordingagentRepository)
        {
            _callrecordingagentRepository = callrecordingagentRepository;

            RuleFor(p => p.Cost)
               .NotEmpty().WithMessage("{PropertyName} is required.");


            RuleFor(p => p.Duration)
              .NotEmpty().WithMessage("{PropertyName} is required.");


            RuleFor(p => p.CallStatus)
                .NotEmpty().WithMessage("{PropertyName} is required.");
            //.NotNull()
            //.GreaterThan(DateTime.Today);

            RuleFor(p => p.Country)
                .NotEmpty().WithMessage("{PropertyName} is required.");
                

        }
    }
}
