using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerList;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Profiles
{
    public class SubscriptionCustomerVmCustomMapper : ITypeConverter<SubscriptionCustomer, SubscriptionCustomersListVm>
    {
        private readonly IDataProtector _protector;

        public SubscriptionCustomerVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public SubscriptionCustomersListVm Convert(SubscriptionCustomer sourc, SubscriptionCustomersListVm destination, ResolutionContext context)
        {

            SubscriptionCustomersListVm des = new SubscriptionCustomersListVm()
            {
                SubscriptionCustomerID = _protector.Protect(sourc.SubscriptionCustomerID.ToString()),
                SubscriptionType= sourc.SubscriptionType,
                CustomerId = sourc.CustomerId,
                SubscriptionEndDate = sourc.SubscriptionEndDate,
                SubscriptionStartDate = sourc.SubscriptionStartDate,
                ISActive = sourc.ISActive,                
            };

            return des;
        }
    }
}
