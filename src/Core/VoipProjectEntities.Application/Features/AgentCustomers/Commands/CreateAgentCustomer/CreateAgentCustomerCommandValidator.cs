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

        

        }

        //private async Task<bool> AgentCustomerNameUnique(CreateAgentCustomerCommand e, CancellationToken token)
        //{
        //    return !(await _agentcustomerRepository.IsAgentCustomerNameUnique(e.AgentName));
        //}


    }
}
