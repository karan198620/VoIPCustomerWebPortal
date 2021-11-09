using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Settings.Commands.DeleteSetting
{
    public class DeleteSettingCommandHandler : IRequestHandler<DeleteSettingCommand>
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IDataProtector _protector;

        public DeleteSettingCommandHandler(ISettingRepository settingRepository, IDataProtectionProvider provider)
        {
            _settingRepository = settingRepository;
            _protector = provider.CreateProtector("");
        }
        public async Task<Unit> Handle(DeleteSettingCommand request, CancellationToken cancellationToken)
        {
            var settingId = new Guid(_protector.Unprotect(request.SettingID));
            var settingToDelete = await _settingRepository.GetByIdAsync(settingId);

            if (settingToDelete == null)
            {
                throw new NotFoundException(nameof(Setting), settingId);
            }

            await _settingRepository.DeleteAsync(settingToDelete);
            return Unit.Value;
        }
    }
}
