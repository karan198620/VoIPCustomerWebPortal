using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipApplicationProject.Models;

namespace VoipApplicationProject.RootObjects
{
    public class RootObject
    {
        #region "Menu Access"
        public class RootMenu
        {
            public string status { get; set; }
            public MenuAccessModel[] data { get; set; }
        }
        #endregion
    }
}
