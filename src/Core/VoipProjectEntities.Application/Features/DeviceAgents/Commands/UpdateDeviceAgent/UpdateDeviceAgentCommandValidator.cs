using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Commands.UpdateDeviceAgent
{
   public class UpdateDeviceAgentCommandValidator : AbstractValidator<UpdateDeviceAgentCommand>
    {
        public UpdateDeviceAgentCommandValidator()
        {
            RuleFor(p => p.MacAddress)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Today);
            RuleFor(p => p.UpdatedAt)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .GreaterThan(DateTime.Now);
            RuleFor(p => p.DeviceProfileType)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
            RuleFor(p => p.IsWorking)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();

        }
    }
}
