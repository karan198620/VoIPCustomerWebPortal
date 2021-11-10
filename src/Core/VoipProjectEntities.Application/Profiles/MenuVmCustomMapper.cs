using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.Menu.Queries.GetMenu;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Profiles
{
    public class MenuVmCustomMapper : ITypeConverter<MenuAccess, MenuListVm>
    {
        private readonly IDataProtector _protector;

        public MenuVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public MenuListVm Convert(MenuAccess source, MenuListVm destination, ResolutionContext context)
        {
            MenuListVm des = new MenuListVm()
            {
                MenuAccessId = _protector.Protect(source.MenuAccessId.ToString()),
                MenuLink = source.MenuLink,
                CreatedAt = source.CreatedAt,
                UpdatedAt = source.UpdatedAt,
                CustomerID = _protector.Protect(source.CustomerId.ToString()),
                IsAccess = source.IsAccess,
            };
            return des;
        }
    }
}
