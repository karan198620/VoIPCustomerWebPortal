using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipApplicationProject.Models;
using static VoipApplicationProject.RootObjects.RootObject;

namespace VoipApplicationProject.Repositories
{
    public interface IDashboardRepo
    {
        RootMenu GetMenu(string CustomerId, bool IsAccess, string token);
    }
}
