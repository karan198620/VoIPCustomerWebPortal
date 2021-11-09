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

namespace VoipProjectEntities.Application.Features.Settings.Queries.GetSettingsList
{
    public class GetSettingsListQueryHandler : IRequestHandler<GetSettingsListQuery, Response<IEnumerable<SettingsListVm>>>
    {
        private readonly IAsyncRepository<Setting> _settingRepository;
        private readonly IMapper _mapper;
        public GetSettingsListQueryHandler(IMapper mapper, IAsyncRepository<Setting> settingRepository)
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
        }
        public async Task<Response<IEnumerable<SettingsListVm>>> Handle(GetSettingsListQuery request, CancellationToken cancellationToken)
        {
            var allSettings = (await _settingRepository.ListAllAsync()).OrderBy(x => x.SettingID);
            var settingList = _mapper.Map<List<SettingsListVm>>(allSettings);
            var response = new Response<IEnumerable<SettingsListVm>>(settingList);
            return response;
        }
    }
}
