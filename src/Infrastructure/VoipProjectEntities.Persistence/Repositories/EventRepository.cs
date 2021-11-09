using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly ILogger _logger;
        public EventRepository(ApplicationDbContext dbContext, ILogger<Event> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            _logger.LogInformation("GetCategoriesWithEvents Initiated");
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
            _logger.LogInformation("GetCategoriesWithEvents Completed");
            return Task.FromResult(matches);
        }
    }
}
