using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Menu.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Response<CreateMenuDto>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IMapper mapper, IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public async Task<Response<CreateMenuDto>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var createMenuCommandResponse = new Response<CreateMenuDto>();

            var validator = new CreateMenuCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createMenuCommandResponse.Succeeded = false;
                createMenuCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createMenuCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var menu = new VoipProjectEntities.Domain.Entities.MenuAccess() { CreatedAt = request.CreatedAt, CustomerId = request.Id, IsAccess = request.IsAccess, MenuLink = request.MenuLink, UpdatedAt = request.UpdatedAt };
                menu = await _menuRepository.AddAsync(menu);
                createMenuCommandResponse.Data = _mapper.Map<CreateMenuDto>(menu);
                createMenuCommandResponse.Succeeded = true;
                createMenuCommandResponse.Message = "success";
            }

            return createMenuCommandResponse;
        }
    }
}
