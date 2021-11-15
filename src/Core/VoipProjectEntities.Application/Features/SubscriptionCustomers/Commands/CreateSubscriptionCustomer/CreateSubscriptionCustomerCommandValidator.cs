using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Contracts.Persistence;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.CreateSubscriptionCustomer
{
    public class CreateSubscriptionCustomerCommandValidator : AbstractValidator<CreateSubscriptionCustomerCommand>
    {
        private readonly ISubscriptionCustomerRepository _subscriptioncustomerRepository;

        public CreateSubscriptionCustomerCommandValidator(ISubscriptionCustomerRepository subscriptioncustomerRepository)
        {
            _subscriptioncustomerRepository = subscriptioncustomerRepository;

           

        }
    }
}
