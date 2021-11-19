using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Persistence.Repositories
{
   public class TrailBalanceCustomerRepository : BaseRepository<TrailBalanceCustomer>, ITrailBalanceCustomerRepository
    {
        private readonly ILogger _logger;
        public TrailBalanceCustomerRepository(ApplicationDbContext dbContext, ILogger<TrailBalanceCustomer> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<TrailBalanceCustomer>> GetTrialBalanceWithCustomers()
        {
            _logger.LogInformation("GetTrialBalanceWithCustomers Initiated");
            var AllTBR = await _dbContext.TrailBalanceCustomers.ToListAsync();
            _logger.LogInformation("GetTrialBalanceWithCustomers Completed");
            return AllTBR;
        }
    }
}
