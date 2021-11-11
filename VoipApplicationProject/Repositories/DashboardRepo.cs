using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using VoipApplicationProject.Models;
using static VoipApplicationProject.RootObjects.RootObject;

namespace VoipApplicationProject.Repositories
{
    public class DashboardRepo : IDashboardRepo
    {
        string Baseurl = "https://localhost:44330/";        

        #region "Get Menu List For Customer"
        public RootMenu GetMenu(string CustomerId, bool IsAccess, string token)
        {
            try
            {
                List<MenuAccessModel> MenuList = new List<MenuAccessModel>();
                RootMenu menuRoot = new RootMenu();

                HttpClient HC = new HttpClient();
                HC.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var Record = HC.GetAsync(Baseurl + "api/Menu/all/" + CustomerId + "/" + IsAccess);

                Record.Wait();

                var results = Record.Result;

                if (results.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    menuRoot.status = "Unauthorized";
                    return menuRoot;
                }
                else if(results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    menuRoot = JsonConvert.DeserializeObject<RootMenu>(UserResponse);
                    menuRoot.status = "Success";

                    return menuRoot;
                }

                HC.Dispose();
                return menuRoot;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion        
    }
}
