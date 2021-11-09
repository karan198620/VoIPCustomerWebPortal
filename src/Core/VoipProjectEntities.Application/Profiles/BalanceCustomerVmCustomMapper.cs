using AutoMapper;
using VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomersList;
using VoipProjectEntities.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Profiles
{
    public class BalanceCustomerVmCustomMapper : ITypeConverter<BalanceCustomer, BalanceCustomerListVm>
    {
        private readonly IDataProtector _protector;

        public BalanceCustomerVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }



        public BalanceCustomerListVm Convert(BalanceCustomer source, BalanceCustomerListVm destination, ResolutionContext context)
        {
            BalanceCustomerListVm dest = new BalanceCustomerListVm()
            {
                //AgentCustomerID = _protector.Protect(source.AgentCustomerID.ToString()),
                //AgentName = source.AgentName,
                //Password = source.Password,
                //ISMigratedAt = source.ISMigratedAt

                BalanceCustomerID = _protector.Protect(source.BalanceCustomerID.ToString()),
                BalanceAmount = source.BalanceAmount,
                TranscationType = source.TranscationType,

            };

            return dest;

            //throw new NotImplementedException();
        }
    }
}
