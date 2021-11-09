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

namespace VoipProjectEntities.Application.Features.MenuAccesses.Command.DeleteMenuAccess
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand>
    {
        private readonly IMenuRepository _menuAccessRepository;
        private readonly IDataProtector _protector;

        public DeleteMenuCommandHandler(IMenuRepository menuAccessRepository, IDataProtectionProvider provider)
        {
            _menuAccessRepository = menuAccessRepository;
            _protector = provider.CreateProtector("");
        }
        public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menuAccessId = new Guid(_protector.Unprotect(request.MenuAccessId));
            var menuAccessToDelete = await _menuAccessRepository.GetByIdAsync(menuAccessId);

            if (menuAccessToDelete == null)
            {
                throw new NotFoundException(nameof(MenuAccess), menuAccessId);
            }

            await _menuAccessRepository.DeleteAsync(menuAccessToDelete);
            return Unit.Value;

        }
    }
}
