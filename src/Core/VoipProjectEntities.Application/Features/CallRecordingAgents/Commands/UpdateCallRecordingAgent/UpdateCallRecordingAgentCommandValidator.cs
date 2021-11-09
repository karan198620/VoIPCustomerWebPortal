using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.UpdateCallRecordingAgent
{
    public class UpdateCallRecordingAgentCommandValidator : AbstractValidator<UpdateCallRecordingAgentCommand>
    {
        public UpdateCallRecordingAgentCommandValidator()
        {
            RuleFor(p => p.CallStatus)
                .NotEmpty().WithMessage("{PropertyName} is required.");


            RuleFor(p => p.Cost)
                .NotEmpty().WithMessage("{PropertyName} is required.");


            RuleFor(p => p.Country)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Duration)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
