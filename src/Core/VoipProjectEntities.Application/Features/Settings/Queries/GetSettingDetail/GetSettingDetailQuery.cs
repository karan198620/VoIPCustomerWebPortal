using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Settings.Queries.GetSettingDetail
{
    public class GetSettingDetailQuery : IRequest<Response<SettingDetailVm>>
    {
        public string Id { get; set; }
    }
}
