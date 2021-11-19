using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.TrailBalanceCustomers.Queries.GetTrailBalanceCustomersList;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Profiles
{
    public class TrailBalanceCustomerVmCustomMapper : ITypeConverter<TrailBalanceCustomer, TrailBalanceCustomerListVm>
    {
        private readonly IDataProtector _protector;

        public TrailBalanceCustomerVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public TrailBalanceCustomerListVm Convert(TrailBalanceCustomer source, TrailBalanceCustomerListVm destination, ResolutionContext context)
        {
            TrailBalanceCustomerListVm dest = new TrailBalanceCustomerListVm()
            {
                TrailBalanceCustomerId = _protector.Protect(source.TrailBalanceCustomerId.ToString()),
                Date = source.Date,
                TransactionType = source.TransactionType,
                CustomerId = source.CustomerId,
                Amount = source.Amount,
                CreatedAt = source.CreatedAt,
                UpdatedAt = source.UpdatedAt
            };

            return dest;
        }
    }
}
