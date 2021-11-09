using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.Settings.Commands.UpdateSetting
{
    public class UpdateSettingCommandValidator : AbstractValidator<UpdateSettingCommand>
    {
        public UpdateSettingCommandValidator()
        {
            RuleFor(p => p.SettingType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


            RuleFor(p => p.Value1)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Value2)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Value3)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.UpdatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Today);
        }
    }
}
