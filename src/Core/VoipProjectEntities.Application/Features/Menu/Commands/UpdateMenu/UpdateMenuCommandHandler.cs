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

namespace VoipProjectEntities.Application.Features.MenuAccesses.Commands.UpdateMenuAccess
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, Response<Guid>>
    {
        private readonly IMenuRepository _menuAccessRepository;
        private readonly IMapper _mapper;

        public UpdateMenuCommandHandler(IMapper mapper, IMenuRepository menuAccessRepository)
        {
            _mapper = mapper;
            _menuAccessRepository = menuAccessRepository;
        }
        public async Task<Response<Guid>> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menuAccessToUpdate = await _menuAccessRepository.GetByIdAsync(request.MenuAccessId);

            if (menuAccessToUpdate == null)
            {
                throw new NotFoundException(nameof(MenuAccess), request.MenuAccessId);
            }

            var validator = new UpdateMenuCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, menuAccessToUpdate, typeof(UpdateMenuCommand), typeof(MenuAccess));

            await _menuAccessRepository.UpdateAsync(menuAccessToUpdate);

            return new Response<Guid>(request.MenuAccessId, "Updated successfully ");
        }
    }
}
