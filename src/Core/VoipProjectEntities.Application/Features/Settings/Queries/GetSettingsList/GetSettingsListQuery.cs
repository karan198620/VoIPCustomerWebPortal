using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Settings.Queries.GetSettingsList
{
    public class GetSettingsListQuery : IRequest<Response<IEnumerable<SettingsListVm>>>
    {
    }
}
