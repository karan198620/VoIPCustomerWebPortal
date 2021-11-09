using System;

namespace VoipProjectEntities.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
