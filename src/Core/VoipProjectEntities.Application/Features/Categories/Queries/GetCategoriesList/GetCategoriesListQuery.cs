using MediatR;
using System.Collections.Generic;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
