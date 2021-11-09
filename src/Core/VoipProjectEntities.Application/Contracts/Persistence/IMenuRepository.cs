using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Contracts.Persistence
{
    public interface IMenuRepository : IAsyncRepository<MenuAccess>
    {
        Task GetByIdAsync(string menuAccessId);
    }
}
