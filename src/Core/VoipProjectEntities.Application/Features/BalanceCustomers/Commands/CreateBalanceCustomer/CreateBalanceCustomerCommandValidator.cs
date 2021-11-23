using VoipProjectEntities.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Commands.CreateBalanceCustomer
{
    public class CreateBalanceCustomerCommandValidator : AbstractValidator<CreateBalanceCustomerCommand>
    {
        private readonly IBalanceCustomerRepository _balancecustomerRepository;


        public CreateBalanceCustomerCommandValidator(IBalanceCustomerRepository balancecustomerRepository)
        {
            _balancecustomerRepository = balancecustomerRepository;

            //RuleFor(p => p.BalanceAmount)
            //   .NotEmpty().WithMessage("{PropertyName} is required.");

            ////.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            //RuleFor(p => p.TranscationType)
            //    .NotEmpty().WithMessage("{PropertyName} is required.");






        }
    }
}