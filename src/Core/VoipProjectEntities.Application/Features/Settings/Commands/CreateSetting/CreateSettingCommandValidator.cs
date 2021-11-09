using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Contracts.Persistence;

namespace VoipProjectEntities.Application.Features.Settings.Commands.CreateSetting
{
    public class CreateSettingCommandValidator : AbstractValidator<CreateSettingCommand>
    {
        private readonly ISettingRepository _settingRepository;

        public CreateSettingCommandValidator(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;

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
