using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;


namespace VoipProjectEntities.Application.Features.AgentCustomers.Commands.DeleteAgentCustomer
{
    class DeleteAgentCustomerCommandHandler  : IRequestHandler<DeleteAgentCustomerCommand>
    {
        private readonly IAgentCustomerRepository _agentcustomerRepository;
        private readonly IDataProtector _protector;


        public DeleteAgentCustomerCommandHandler(IAgentCustomerRepository agentcustomerRepository, IDataProtectionProvider provider)
        {
            _agentcustomerRepository = agentcustomerRepository;
            _protector = provider.CreateProtector("");
        }

        //public async Task<Unit> Handle(DeleteAgentCustomerCommandHandler request, CancellationToken cancellationToken)
        //{
        //    var agentcustomerId = new Guid(_protector.Unprotect(request.Ag));
        //    var agentcustomerToDelete = await _agentcustomerRepository.GetByIdAsync(agentcustomerId);

        //    if (agentcustomerToDelete == null)
        //    {
        //        throw new NotFoundException(nameof(Event), agentcustomerId);
        //    }

        //    await _agentcustomerRepository.DeleteAsync(agentcustomerToDelete);
        //    return Unit.Value;



        //    //throw new NotImplementedException();
        //}

        public async Task<Unit> Handle(DeleteAgentCustomerCommand request, CancellationToken cancellationToken)
        {

            var agentcustomerId = new Guid(_protector.Unprotect(request.AgentCustomerID));
            var agentcustomerToDelete = await _agentcustomerRepository.GetByIdAsync(agentcustomerId);


            if (agentcustomerToDelete == null)
            {
               throw new NotFoundException(nameof(Event), agentcustomerId);
            }

                    await _agentcustomerRepository.DeleteAsync(agentcustomerToDelete);
                    return Unit.Value;
                //throw new NotImplementedException();
        }
    }
}
