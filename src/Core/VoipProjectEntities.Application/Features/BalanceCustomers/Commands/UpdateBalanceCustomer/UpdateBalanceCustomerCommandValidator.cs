using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Commands.UpdateBalanceCustomer
{
    public class UpdateBalanceCustomerCommandValidator : AbstractValidator<UpdateBalanceCustomerCommand>
    {
        public UpdateBalanceCustomerCommandValidator()
        {
            RuleFor(p => p.BalanceAmount)
                .NotEmpty().WithMessage("{PropertyName} is required.");
            //.NotNull()
            //.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.TranscationType)
                .NotEmpty().WithMessage("{PropertyName} is required.");
                //.NotNull();
        }
    }
}
