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
    public class CreateMenuCommandHandler : IMenuRequestHandler
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IMapper mapper, IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public async Task<Response<List<CreateMenuDto>>> Handle(CreateMenuCommand[] request, CancellationToken cancellationToken)
        {
            var createMenuCommandResponse = new Response<List<CreateMenuDto>>();

            List<MenuAccess> newMenu = new List<MenuAccess>();

            foreach (var menuitems in request)
            {
                var validator = new CreateMenuCommandValidator();
                var validationResult = await validator.ValidateAsync(menuitems);

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
                    newMenu = new List<MenuAccess>() {
                                    new MenuAccess() {
                                        CreatedAt = menuitems.CreatedAt,
                                        CustomerId = menuitems.CustomerId,
                                        IsAccess = menuitems.IsAccess,
                                        MenuLink = menuitems.MenuLink,
                                        UpdatedAt = menuitems.UpdatedAt  }
                        };

                    await _menuRepository.InsertRangeAsync(newMenu);
                    createMenuCommandResponse.Data = _mapper.Map<List<CreateMenuDto>>(newMenu);
                    createMenuCommandResponse.Succeeded = true;
                    createMenuCommandResponse.Message = "success";
                }
            }

            return createMenuCommandResponse;
        }
    }
}
