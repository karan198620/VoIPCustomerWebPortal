using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(p => p.CustomerName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(8).WithMessage("{PropertyName} must have  8 characters.")
                .MaximumLength(15).WithMessage("{PropertyName} must not exceed 15 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            //RuleFor(p => p.CustomerTypeID)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull();

            //RuleFor(p => p.ISMigrated)
            //    .NotEmpty().WithMessage("{PropertyName} is required.");


            //RuleFor(p => p.ISTrialBalanceOpted)
            //    .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.UpdatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()                
                .GreaterThanOrEqualTo(p => p.CreatedAt).WithMessage("{PropertyName} is InValid");

            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Today.AddDays(-1)).WithMessage("{PropertyName} is InValid");
        }
    }
}
