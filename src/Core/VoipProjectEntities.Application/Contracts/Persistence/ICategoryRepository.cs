using System.Collections.Generic;
using System.Threading.Tasks;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}
