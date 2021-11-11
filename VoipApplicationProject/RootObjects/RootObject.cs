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

        #region "Customer"
        public class RootCustomer
        {
            public string status { get; set; }
            public string userid { get; set; }
            public string email { get; set; }
            public bool isAuthenticated { get; set; }
            public string id { get; set; }
            public CustomerType CustomerTypeId { get; set; }
            public string userName { get; set; }
            public string token { get; set; }
            public string refreshToken { get; set; }
            public string refreshTokenExpiration { get; set; }
            public string message { get; set; }
        }
        #endregion
    }
}
