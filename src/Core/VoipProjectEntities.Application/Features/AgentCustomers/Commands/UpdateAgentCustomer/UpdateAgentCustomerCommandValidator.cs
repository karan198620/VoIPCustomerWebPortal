using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.Events.Commands.UpdateEvent;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Commands.UpdateAgentCustomer
{
    public class UpdateAgentCustomerCommandValidator : AbstractValidator<UpdateAgentCustomerCommand>
    {
        public UpdateAgentCustomerCommandValidator()
        {
            RuleFor(p => p.AgentName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }


    }
}
