using FluentValidation;

namespace VoipProjectEntities.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");
        }
    }
}
