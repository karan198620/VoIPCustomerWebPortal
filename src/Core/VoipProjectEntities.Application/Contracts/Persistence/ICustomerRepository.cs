using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
    }
}
