using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerList;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Profiles
{
    public class CustomerVmCustomMapper : ITypeConverter<Customer, CustomerListVm>
    {
        private readonly IDataProtector _protector;

        public CustomerVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public CustomerListVm Convert(Customer source, CustomerListVm destination, ResolutionContext context)
        {
            CustomerListVm des = new CustomerListVm()
            {
                Id = _protector.Protect(source.CustomerId.ToString()),
                CustomerName = source.CustomerName,
                CustomerTypeID = source.CustomerTypeID,
                Email = source.Email,
                Password = source.Password,
                ISMigrated = source.ISMigrated,
                ISTrialBalanceOpted = source.ISTrialBalanceOpted,
            };
            return des;
        }
    }
}
