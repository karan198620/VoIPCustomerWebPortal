using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Settings.Queries.GetSettingDetail
{
    public class GetSettingDetailQueryHandler : IRequestHandler<GetSettingDetailQuery, Response<SettingDetailVm>>
    {
        private readonly IAsyncRepository<Setting> _settingRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetSettingDetailQueryHandler(IMapper mapper, IAsyncRepository<Setting> settingRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
            _protector = provider.CreateProtector("");
        }
        public async Task<Response<SettingDetailVm>> Handle(GetSettingDetailQuery request, CancellationToken cancellationToken)
        {
            string id = _protector.Unprotect(request.Id);

            var @setting = await _settingRepository.GetByIdAsync(new Guid(id));
            var settingDetailDto = _mapper.Map<SettingDetailVm>(@setting);
            var response = new Response<SettingDetailVm>(settingDetailDto);
            return response;
        }
    }
}
