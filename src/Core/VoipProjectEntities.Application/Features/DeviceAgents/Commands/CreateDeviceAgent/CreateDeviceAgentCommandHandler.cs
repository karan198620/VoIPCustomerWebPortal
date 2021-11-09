using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Infrastructure;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Models.Mail;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Commands.CreateDeviceAgent
{
    public class CreateDeviceAgentCommandHandler : IRequestHandler<CreateDeviceAgentCommand, Response<Guid>>
    {

        private readonly IDeviceAgentRepository _deviceAgentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateDeviceAgentCommandHandler> _logger;


        public CreateDeviceAgentCommandHandler(IMapper mapper, IDeviceAgentRepository deviceAgentRepository, IEmailService emailService, ILogger<CreateDeviceAgentCommandHandler> logger)
        {
            _mapper = mapper;
            _deviceAgentRepository = deviceAgentRepository;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Response<Guid>> Handle(CreateDeviceAgentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var validator = new CreateDeviceAgentCommandValidator(_deviceAgentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var deviceAgent = _mapper.Map<DeviceAgent>(request);

            @deviceAgent = await _deviceAgentRepository.AddAsync(@deviceAgent);

            //Sending email notification to admin address
            var email = new Email() { To = "gill@snowball.be", Body = $"A new device Agent was created: {request}", Subject = "A new Device Agent was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about event {@deviceAgent.DeviceAgentId} failed due to an error with the mail service: {ex.Message}");
            }

            var response = new Response<Guid>(@deviceAgent.DeviceAgentId, "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;
        }
    }
}
