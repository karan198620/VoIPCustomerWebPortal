using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Persistence.Repositories
{
    public class AgentCustomerRepository : BaseRepository<AgentCustomer>, IAgentCustomerRepository
    {
        private readonly ILogger _logger;
        public AgentCustomerRepository(ApplicationDbContext dbContext, ILogger<AgentCustomer> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
