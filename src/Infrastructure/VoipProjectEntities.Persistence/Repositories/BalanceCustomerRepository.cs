using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Persistence.Repositories
{
    public class BalanceCustomerRepository : BaseRepository<BalanceCustomer>, IBalanceCustomerRepository
    {
        private readonly ILogger _logger;
        public BalanceCustomerRepository(ApplicationDbContext dbContext, ILogger<BalanceCustomer> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
