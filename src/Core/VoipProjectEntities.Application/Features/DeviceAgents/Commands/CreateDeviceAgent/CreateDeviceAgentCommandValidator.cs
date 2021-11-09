using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Commands.CreateDeviceAgent
{
    public class CreateDeviceAgentCommandValidator : AbstractValidator<CreateDeviceAgentCommand>
    {
        private readonly IDeviceAgentRepository _deviceAgentRepository;
       
        public CreateDeviceAgentCommandValidator(IDeviceAgentRepository deviceAgentRepository)
        {
            _deviceAgentRepository = deviceAgentRepository;

            RuleFor(p => p.MacAddress)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Today);
            RuleFor(p => p.UpdatedAt)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .GreaterThan(DateTime.Now);
            RuleFor(p => p.DeviceProfileType)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
            RuleFor(p => p.IsWorking)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();             
        }
    }
}
