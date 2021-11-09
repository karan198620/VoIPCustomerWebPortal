using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.Settings.Queries.GetSettingDetail
{
    public class SettingDetailVm
    {
        public Guid SettingID { get; set; }
        public Guid CustomerID { get; set; }
        public int SettingType { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
    }
}
