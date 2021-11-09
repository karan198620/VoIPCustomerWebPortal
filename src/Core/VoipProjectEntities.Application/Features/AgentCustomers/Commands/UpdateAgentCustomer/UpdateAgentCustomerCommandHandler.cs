using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;



namespace VoipProjectEntities.Application.Features.AgentCustomers.Commands.UpdateAgentCustomer
{
    public class UpdateAgentCustomerCommandHandler : IRequestHandler<UpdateAgentCustomerCommand, Response<Guid>>
    {
        private readonly IAgentCustomerRepository _agentcustomerRepository;
        private readonly IMapper _mapper;
        //private readonly IAgentCustomerRepository _agentcustomerRepository;

        public UpdateAgentCustomerCommandHandler(IMapper mapper, IAgentCustomerRepository agentcustomerRepository)
        {
            _mapper = mapper;
            _agentcustomerRepository = agentcustomerRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateAgentCustomerCommand request, CancellationToken cancellationToken)
        {
           var agentcustomerToUpdate = await _agentcustomerRepository.GetByIdAsync(request.AgentCustomerID);

          if (agentcustomerToUpdate == null)
          {
                throw new NotFoundException(nameof(AgentCustomer), request.AgentCustomerID);
            }

            var validator = new UpdateAgentCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, agentcustomerToUpdate, typeof(UpdateAgentCustomerCommand), typeof(Event));

            await _agentcustomerRepository.UpdateAsync(agentcustomerToUpdate);

            return new Response<Guid>(request.AgentCustomerID, "Updated successfully ");

            //throw new NotImplementedException();
        }


    }
}
