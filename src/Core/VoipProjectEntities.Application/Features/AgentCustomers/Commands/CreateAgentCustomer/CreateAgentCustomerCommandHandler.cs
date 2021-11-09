using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Infrastructure;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Models.Mail;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;


namespace VoipProjectEntities.Application.Features.AgentCustomers.Commands.CreateAgentCustomer
{
    class CreateAgentCustomerCommandHandler : IRequestHandler<CreateAgentCustomerCommand, Response<Guid>>
    {
        private readonly IAgentCustomerRepository _agentcustomerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateAgentCustomerCommandHandler> _logger;


        public CreateAgentCustomerCommandHandler(IMapper mapper, IAgentCustomerRepository agentcustomerRepository, IEmailService emailService, ILogger<CreateAgentCustomerCommandHandler> logger)
        {
            _mapper = mapper;
            _agentcustomerRepository = agentcustomerRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Response<Guid>> Handle(CreateAgentCustomerCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var validator = new CreateAgentCustomerCommandValidator(_agentcustomerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<AgentCustomer>(request);

            @event = await _agentcustomerRepository.AddAsync(@event);

            var response = new Response<Guid>(@event.AgentCustomerID, "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;


            //throw new NotImplementedException();


        }
    }

   

}
