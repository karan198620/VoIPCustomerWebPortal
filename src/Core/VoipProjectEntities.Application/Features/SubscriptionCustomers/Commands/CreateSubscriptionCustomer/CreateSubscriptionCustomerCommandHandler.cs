using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.CreateSubscriptionCustomer
{
    public class CreateSubscriptionCustomerCommandHandler : IRequestHandler<CreateSubscriptionCustomerCommand, Response<Guid>>
    {
        private readonly ISubscriptionCustomerRepository _subscriptioncustomerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSubscriptionCustomerCommandHandler> _logger;

        public CreateSubscriptionCustomerCommandHandler(IMapper mapper, ISubscriptionCustomerRepository subscriptioncustomerRepository, ILogger<CreateSubscriptionCustomerCommandHandler> logger)
        {
            _mapper = mapper;
            _subscriptioncustomerRepository = subscriptioncustomerRepository;
            _logger = logger;
        }
        public async  Task<Response<Guid>> Handle(CreateSubscriptionCustomerCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var validator = new CreateSubscriptionCustomerCommandValidator(_subscriptioncustomerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @subscription = _mapper.Map<SubscriptionCustomer>(request);

            @subscription = await _subscriptioncustomerRepository.AddAsync(@subscription);


            var response = new Response<Guid>(@subscription.SubscriptionCustomerID, "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;
        }
    }
}
