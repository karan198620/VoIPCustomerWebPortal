using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Persistence.Repositories
{
   public class DeviceAgentRepository : BaseRepository<DeviceAgent>, IDeviceAgentRepository
    {
        private readonly ILogger _logger;
        public DeviceAgentRepository(ApplicationDbContext dbContext, ILogger<DeviceAgent> logger) : base(dbContext, logger)
        {
           _logger = logger;
        }
    }
}
