using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;

namespace VoipProjectEntities.Application.Features.AgentCustomers.Commands.CreateAgentCustomer
{
    public class CreateAgentCustomerCommandValidator : AbstractValidator<CreateAgentCustomerCommand>
    {
        private readonly IAgentCustomerRepository _agentcustomerRepository;


        public CreateAgentCustomerCommandValidator(IAgentCustomerRepository agentcustomerRepository)
        {
            _agentcustomerRepository = agentcustomerRepository;

            RuleFor(p => p.AgentName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
               // .GreaterThan(DateTime.Now);

            //RuleFor(e => e)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .MustAsync(AgentCustomerNameUnique)
            //    .WithMessage("An event with the same name and date already exists.");

            //RuleFor(p => p.Price)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .GreaterThan(0);

            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Today);

            RuleFor(p => p.UpdatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

        }

        //private async Task<bool> AgentCustomerNameUnique(CreateAgentCustomerCommand e, CancellationToken token)
        //{
        //    return !(await _agentcustomerRepository.IsAgentCustomerNameUnique(e.AgentName));
        //}


    }
}
