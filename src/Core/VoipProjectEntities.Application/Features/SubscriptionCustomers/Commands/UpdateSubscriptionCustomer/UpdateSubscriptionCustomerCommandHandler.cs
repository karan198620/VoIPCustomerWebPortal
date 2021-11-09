using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.UpdateSubscriptionCustomer
{
    public class UpdateSubscriptionCustomerCommandHandler : IRequestHandler<UpdateSubscriptionCustomerCommand, Response<Guid>>
    {
        private readonly ISubscriptionCustomerRepository _subscriptioncustomerRepository;
        private readonly IMapper _mapper;

        public UpdateSubscriptionCustomerCommandHandler(IMapper mapper, ISubscriptionCustomerRepository subscriptioncustomerRepository)
        {
            _mapper = mapper;
            _subscriptioncustomerRepository = subscriptioncustomerRepository;
        }
        public async Task<Response<Guid>> Handle(UpdateSubscriptionCustomerCommand request, CancellationToken cancellationToken)
        {
            var subscriptioncustomerToUpdate = await _subscriptioncustomerRepository.GetByIdAsync(request.SubscriptionCustomerID);

            if (subscriptioncustomerToUpdate == null)
            {
                throw new NotFoundException(nameof(SubscriptionCustomer), request.SubscriptionCustomerID );
            }

            var validator = new UpdateSubscriptionCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, subscriptioncustomerToUpdate, typeof(UpdateSubscriptionCustomerCommand), typeof(Setting));

            await _subscriptioncustomerRepository.UpdateAsync(subscriptioncustomerToUpdate);

            return new Response<Guid>(request.SubscriptionCustomerID, "Updated successfully ");
        }
    }
}
