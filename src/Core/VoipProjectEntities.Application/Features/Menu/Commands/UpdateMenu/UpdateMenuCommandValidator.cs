using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.MenuAccesses.Commands.UpdateMenuAccess
{
    public class UpdateMenuCommandValidator : AbstractValidator<UpdateMenuCommand>
    {
        public UpdateMenuCommandValidator()
        {

            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Today);
            RuleFor(p => p.UpdatedAt)
                   .NotEmpty().WithMessage("{PropertyName} is required.")
                   .NotNull()
                   .GreaterThan(DateTime.Now);
            RuleFor(p => p.MenuLink)
                   .NotEmpty().WithMessage("{PropertyName} is required.")
                   .NotNull();
            RuleFor(p => p.IsAccess)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();
        }
    }
}
