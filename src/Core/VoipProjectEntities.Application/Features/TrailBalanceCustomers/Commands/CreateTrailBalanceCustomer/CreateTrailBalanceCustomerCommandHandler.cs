using AutoMapper;
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

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.CreateTrialBalanceCustomer
{
    public class CreateTrailBalanceCustomerCommandHandler : IRequestHandler<CreateTrailBalanceCustomerCommand, Response<Guid>>
    {
        private readonly ITrailBalanceCustomerRepository _trailBalanceCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateTrailBalanceCustomerCommandHandler> _logger;

        public CreateTrailBalanceCustomerCommandHandler(IMapper mapper, ITrailBalanceCustomerRepository trailBalanceCustomerRepository, IEmailService emailService, ILogger<CreateTrailBalanceCustomerCommandHandler> logger)
        {
            _mapper = mapper;
            _trailBalanceCustomerRepository = trailBalanceCustomerRepository;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Response<Guid>> Handle(CreateTrailBalanceCustomerCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var validator = new CreateTrailBalanceCustomerCommandValidator(_trailBalanceCustomerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var trailBalanceCustomer = _mapper.Map<TrailBalanceCustomer>(request);

            @trailBalanceCustomer = await _trailBalanceCustomerRepository.AddAsync(@trailBalanceCustomer);

            //Sending email notification to admin address
            var email = new Email() { To = "gill@snowball.be", Body = $"A new TrailBalanceCustomer was created: {request}", Subject = "A new TrailBalanceCustomer was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about event {@trailBalanceCustomer.TrailBalanceCustomerId} failed due to an error with the mail service: {ex.Message}");
            }

            var response = new Response<Guid>(@trailBalanceCustomer.TrailBalanceCustomerId, "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;
        }
    }
}
