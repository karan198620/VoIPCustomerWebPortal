using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.DeleteSubscriptionCustomer
{
    public class DeleteSubscriptionCustomerCommandHandler : IRequestHandler<DeleteSubscriptionCustomerCommand>
    {
        private readonly ISubscriptionCustomerRepository _subscriptioncustomerRepository;
        private readonly IDataProtector _protector;

        public DeleteSubscriptionCustomerCommandHandler(ISubscriptionCustomerRepository subscriptioncustomerRepository, IDataProtectionProvider provider)
        {
            _subscriptioncustomerRepository = subscriptioncustomerRepository;
            _protector = provider.CreateProtector("");
        }
        public async  Task<Unit> Handle(DeleteSubscriptionCustomerCommand request, CancellationToken cancellationToken)
        {

            var subscriptioncustomerId = new Guid(_protector.Unprotect(request.SubscriptionCustomerID));
            var subscriptioncustomerToDelete = await _subscriptioncustomerRepository.GetByIdAsync(subscriptioncustomerId);

            if (subscriptioncustomerToDelete == null)
            {
                throw new NotFoundException(nameof(SubscriptionCustomer), subscriptioncustomerId);
            }

            await _subscriptioncustomerRepository.DeleteAsync(subscriptioncustomerToDelete);
            return Unit.Value;
        }
    }
}
