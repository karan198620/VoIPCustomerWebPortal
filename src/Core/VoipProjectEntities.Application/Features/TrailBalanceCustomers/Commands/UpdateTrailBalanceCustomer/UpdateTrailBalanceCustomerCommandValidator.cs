using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.UpdateTrialBalanceCustomer
{
   public class UpdateTrailBalanceCustomerCommandValidator : AbstractValidator<UpdateTrailBalanceCustomerCommand>
    {
        public UpdateTrailBalanceCustomerCommandValidator()
        {
            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Today);
            RuleFor(p => p.TransactionType)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

        }
    }
}
