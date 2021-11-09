using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Settings.Commands.CreateSetting
{
    class CreateSettingCommandHandler : IRequestHandler<CreateSettingCommand, Response<Guid>>
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSettingCommandHandler> _logger;


        public CreateSettingCommandHandler(IMapper mapper, ISettingRepository settingRepository, ILogger<CreateSettingCommandHandler> logger)
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
            _logger = logger;
        }
        public async Task<Response<Guid>> Handle(CreateSettingCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var validator = new CreateSettingCommandValidator(_settingRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @setting = _mapper.Map<Setting>(request);

            @setting= await _settingRepository.AddAsync(@setting);


            var response = new Response<Guid>(@setting.SettingID, "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;
        }
    }
}
