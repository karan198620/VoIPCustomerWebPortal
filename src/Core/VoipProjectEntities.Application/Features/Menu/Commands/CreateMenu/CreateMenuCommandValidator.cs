using FluentValidation;
using System;

namespace VoipProjectEntities.Application.Features.Menu.Commands.CreateMenu
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(p => p.MenuLink)
                .NotNull();

            RuleFor(p => p.IsAccess)
                .NotNull();

            RuleFor(p => p.CustomerID)
                .NotNull();

            RuleFor(p => p.UpdatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThanOrEqualTo(p => p.CreatedAt).WithMessage("{PropertyName} is InValid");

            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Today.AddDays(-1)).WithMessage("{PropertyName} is InValid");
        }
    }
}
