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

namespace VoipProjectEntities.Application.Features.DeviceAgents.Commands.UpdateDeviceAgent
{
    public class UpdateDeviceAgentCommandHandler : IRequestHandler<UpdateDeviceAgentCommand, Response<Guid>>
    {
        private readonly IDeviceAgentRepository _deviceAgentRepository;
        private readonly IMapper _mapper;

        public UpdateDeviceAgentCommandHandler(IMapper mapper, IDeviceAgentRepository deviceAgentRepository)
        {
            _mapper = mapper;
            _deviceAgentRepository = deviceAgentRepository;
        }
        public async Task<Response<Guid>> Handle(UpdateDeviceAgentCommand request, CancellationToken cancellationToken)
        {
            var deviceAgentToUpdate = await _deviceAgentRepository.GetByIdAsync(request.DeviceAgentId);

            if (deviceAgentToUpdate == null)
            {
                throw new NotFoundException(nameof(DeviceAgent), request.DeviceAgentId);
            }

            var validator = new UpdateDeviceAgentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, deviceAgentToUpdate, typeof(UpdateDeviceAgentCommand), typeof(DeviceAgent));

            await _deviceAgentRepository.UpdateAsync(deviceAgentToUpdate);

            return new Response<Guid>(request.DeviceAgentId, "Updated successfully ");
        }
    }
}
