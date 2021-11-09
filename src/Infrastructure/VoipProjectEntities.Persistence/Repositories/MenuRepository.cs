using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Persistence.Repositories
{
    public class MenuRepository : BaseRepository<MenuAccess>, IMenuRepository
    {
        private readonly ILogger _logger;
        public MenuRepository(ApplicationDbContext dbContext, ILogger<MenuAccess> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public Task GetByIdAsync(string menuAccessId)
        {
            throw new NotImplementedException();
        }
    }
}
