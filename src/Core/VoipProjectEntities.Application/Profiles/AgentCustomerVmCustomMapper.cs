using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomersList;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Profiles
{
    public class AgentCustomerVmCustomMapper : ITypeConverter<AgentCustomer, AgentCustomerListVm>
    {
        private readonly IDataProtector _protector;

        public AgentCustomerVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public AgentCustomerListVm Convert(AgentCustomer source, AgentCustomerListVm destination, ResolutionContext context)
        {
            AgentCustomerListVm dest = new AgentCustomerListVm()
            {
                AgentCustomerID = _protector.Protect(source.AgentCustomerID.ToString()),
                AgentName = source.AgentName,
                Password = source.Password,
                ISMigratedAt = source.ISMigratedAt
            };

            return dest;
        }
    }
}
