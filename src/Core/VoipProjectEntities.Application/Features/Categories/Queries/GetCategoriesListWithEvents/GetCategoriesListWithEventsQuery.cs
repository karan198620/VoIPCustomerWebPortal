using MediatR;
using System.Collections.Generic;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery : IRequest<Response<IEnumerable<CategoryEventListVm>>>
    {
        public bool IncludeHistory { get; set; }
    }
}
