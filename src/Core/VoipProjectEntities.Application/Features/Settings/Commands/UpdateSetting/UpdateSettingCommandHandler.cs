using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Settings.Commands.UpdateSetting
{
    public class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommand, Response<Guid>>
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public UpdateSettingCommandHandler(IMapper mapper, ISettingRepository settingRepository)
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
        }
        public async Task<Response<Guid>> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            var settingToUpdate = await _settingRepository.GetByIdAsync(request.SettingID);

            if (settingToUpdate == null)
            {
                throw new NotFoundException(nameof(Setting), request.SettingID);
            }

            var validator = new UpdateSettingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, settingToUpdate, typeof(UpdateSettingCommand), typeof(Setting));

            await _settingRepository.UpdateAsync(settingToUpdate);

            return new Response<Guid>(request.SettingID, "Updated successfully ");
        }
    }
}
