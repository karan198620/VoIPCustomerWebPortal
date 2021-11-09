using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Settings.Commands.UpdateSetting
{
    public class UpdateSettingCommand : IRequest<Response<Guid>>
    {
        public Guid SettingID { get; set; }
        public Guid CustomerID { get; set; }
        public int SettingType { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
