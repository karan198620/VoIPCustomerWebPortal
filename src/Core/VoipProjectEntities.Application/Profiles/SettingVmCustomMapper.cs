using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.Settings.Queries.GetSettingsList;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Profiles
{
    public class SettingVmCustomMapper : ITypeConverter<Setting, SettingsListVm>
    {
        private readonly IDataProtector _protector;

        public SettingVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public SettingsListVm Convert(Setting sourc, SettingsListVm destination, ResolutionContext context)
        {
            SettingsListVm des = new SettingsListVm()
            {
                SettingID = _protector.Protect(sourc.SettingID.ToString()),
                SettingType = sourc.SettingType,
                Id = sourc.CustomerId,
                Value1=sourc.Value1,
                Value2=sourc.Value2,
                Value3=sourc.Value3,
            };

            return des;
        }
    }
}
