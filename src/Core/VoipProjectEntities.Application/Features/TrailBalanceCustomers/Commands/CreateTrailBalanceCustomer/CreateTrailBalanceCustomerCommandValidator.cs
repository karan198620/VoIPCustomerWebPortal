using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Contracts.Persistence;

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.CreateTrialBalanceCustomer
{
   public class CreateTrailBalanceCustomerCommandValidator : AbstractValidator<CreateTrailBalanceCustomerCommand>
    {
        private readonly ITrailBalanceCustomerRepository _trailBalanceCustomerRepository;

        public CreateTrailBalanceCustomerCommandValidator(ITrailBalanceCustomerRepository trailBalanceCustomerRepository)
        {
            _trailBalanceCustomerRepository = trailBalanceCustomerRepository;

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.CustomerId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
