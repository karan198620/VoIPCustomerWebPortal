using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Persistence.Repositories
{
    public class SubscriptionCustomerRepository : BaseRepository<SubscriptionCustomer>, ISubscriptionCustomerRepository
    {
        private readonly ILogger _logger;
        public SubscriptionCustomerRepository(ApplicationDbContext dbContext, ILogger<SubscriptionCustomer> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
