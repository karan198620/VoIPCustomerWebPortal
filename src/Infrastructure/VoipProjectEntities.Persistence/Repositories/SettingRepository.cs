using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Persistence.Repositories
{
    public class SettingRepository : BaseRepository<Setting>, ISettingRepository
    {
        private readonly ILogger _logger;
        public SettingRepository(ApplicationDbContext dbContext, ILogger<Setting> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
