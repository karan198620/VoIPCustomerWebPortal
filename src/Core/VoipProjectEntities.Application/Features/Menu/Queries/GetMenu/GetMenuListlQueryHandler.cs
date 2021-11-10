using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Menu.Queries.GetMenu
{
    public class GetMenuListlQueryHandler : IRequestHandler<GetMenuListQuery, Response<IEnumerable<MenuListVm>>>
    {
        private readonly IAsyncRepository<MenuAccess> _menuRepository;
        private readonly IMapper _mapper;

        public GetMenuListlQueryHandler(IMapper mapper, IAsyncRepository<MenuAccess> menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public async Task<Response<IEnumerable<MenuListVm>>> Handle(GetMenuListQuery request, CancellationToken cancellationToken)
        {
            var allMenu = (await _menuRepository.ListAllAsync()).OrderBy(x => x.CreatedAt).Where(m=>m.CustomerId == request.Id && m.IsAccess == request.IsAccess);
            var menuList = _mapper.Map<List<MenuListVm>>(allMenu);
            var response = new Response<IEnumerable<MenuListVm>>(menuList);
            return response;
        }
    }
}
