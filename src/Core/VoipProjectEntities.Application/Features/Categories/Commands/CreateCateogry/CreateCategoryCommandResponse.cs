using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommandResponse
    {
        public CreateCategoryCommandResponse()
        {

        }

        public CreateCategoryDto Category { get; set; }
    }
}