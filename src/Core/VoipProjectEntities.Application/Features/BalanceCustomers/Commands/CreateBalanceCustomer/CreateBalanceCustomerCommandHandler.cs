using AutoMapper;
using VoipProjectEntities.Application.Contracts.Infrastructure;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Commands.CreateBalanceCustomer
{
    public class CreateBalanceCustomerCommandHandler : IRequestHandler<CreateBalanceCustomerCommand, Response<Guid>>
    {
        private readonly IBalanceCustomerRepository _balancecustomerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateBalanceCustomerCommandHandler> _logger;


        public CreateBalanceCustomerCommandHandler(IMapper mapper, IBalanceCustomerRepository balancecustomerRepository, IEmailService emailService, ILogger<CreateBalanceCustomerCommandHandler> logger)
        {
            _mapper = mapper;
            _balancecustomerRepository = balancecustomerRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Response<Guid>> Handle(CreateBalanceCustomerCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var validator = new CreateBalanceCustomerCommandValidator(_balancecustomerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<BalanceCustomer>(request);

            @event = await _balancecustomerRepository.AddAsync(@event);

            var response = new Response<Guid>(@event.BalanceCustomerID, "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;

        }
    }
}
