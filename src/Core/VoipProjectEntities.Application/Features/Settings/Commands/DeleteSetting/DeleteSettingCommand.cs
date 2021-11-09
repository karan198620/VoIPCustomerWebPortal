using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.Settings.Commands.DeleteSetting
{
    public class DeleteSettingCommand : IRequest
    {
        public string SettingID { get; set; }
    }
}
