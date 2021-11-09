using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Persistence.Repositories
{
    public class CallRecordingAgentRepository : BaseRepository<CallRecordingAgent>, ICallRecordingAgentRepository
    {
        private readonly ILogger _logger;
        //private readonly ILogger _logger;
        public CallRecordingAgentRepository(ApplicationDbContext dbContext, ILogger<CallRecordingAgent> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
