using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.Settings.Queries.GetSettingsList
{
    public class SettingsListVm
    {
        public string SettingID { get; set; }
        public int SettingType { get; set; }
        public Guid? Id { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
    }
}
