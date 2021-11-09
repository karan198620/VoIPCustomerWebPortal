using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Features.Menu.Queries.GetMenu;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.MenuAccesses.Queries.GetMenuAccessList
{
    public class GetMenuListQueryHandler : IRequestHandler<GetMenuListQuery, Response<IEnumerable<MenuListVm>>>
    {

        private readonly IAsyncRepository<MenuAccess> _menuAccessRepository;
        private readonly IMapper _mapper;


        public GetMenuListQueryHandler(IMapper mapper, IAsyncRepository<MenuAccess> menuAccessRepository)
        {
            _mapper = mapper;
            _menuAccessRepository = menuAccessRepository;
        }
       
        public async Task<Response<IEnumerable<MenuListVm>>> Handle(GetMenuListQuery request, CancellationToken cancellationToken)
        {

            var allMenuAccess = (await _menuAccessRepository.ListAllAsync()).OrderBy(x => x.MenuAccessId);
            var menuAccessList = _mapper.Map<List<MenuListVm>>(allMenuAccess);
            var response = new Response<IEnumerable<MenuListVm>>(menuAccessList);
            return response;
        }
    }
}
