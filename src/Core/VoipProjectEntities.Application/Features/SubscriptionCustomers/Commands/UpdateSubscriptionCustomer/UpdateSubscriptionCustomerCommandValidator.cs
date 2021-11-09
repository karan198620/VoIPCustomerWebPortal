using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.UpdateSubscriptionCustomer
{
    public class UpdateSubscriptionCustomerCommandValidator : AbstractValidator<UpdateSubscriptionCustomerCommand>
    {
        public UpdateSubscriptionCustomerCommandValidator()
        {
        }
    }
}
