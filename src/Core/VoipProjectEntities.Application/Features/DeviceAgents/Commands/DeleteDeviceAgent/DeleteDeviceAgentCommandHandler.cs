using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Application.Features.Events.Commands.DeleteEvent;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.DeviceAgents.Commands.DeleteDeviceAgent
{
    public class DeleteDeviceAgentCommandHandler : IRequestHandler<DeleteDeviceAgentCommand>
    {
        private readonly IDeviceAgentRepository _deviceAgentRepository;
        private readonly IDataProtector _protector;

        public DeleteDeviceAgentCommandHandler(IDeviceAgentRepository deviceAgentRepository, IDataProtectionProvider provider)
        {
            _deviceAgentRepository = deviceAgentRepository;
            _protector = provider.CreateProtector("");
        }
        public async Task<Unit> Handle(DeleteDeviceAgentCommand request, CancellationToken cancellationToken)
        {
            var deviceAgentId = new Guid(_protector.Unprotect(request.DeviceAgentId));
            var deviceAgentToDelete = await _deviceAgentRepository.GetByIdAsync(deviceAgentId);

            if (deviceAgentToDelete == null)
            {
                throw new NotFoundException(nameof(DeviceAgent), deviceAgentId);
            }

            await _deviceAgentRepository.DeleteAsync(deviceAgentToDelete);
            return Unit.Value;
        }
    }
}
