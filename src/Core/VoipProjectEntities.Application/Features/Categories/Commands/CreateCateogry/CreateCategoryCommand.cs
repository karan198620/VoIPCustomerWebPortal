using MediatR;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommand : IRequest<Response<CreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
