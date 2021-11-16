using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using VoipApplicationProject.Models;

namespace VoipApplicationProject.Repositories
{
    public class DashboardRepo : IDashboardRepo
    {
        string Baseurl = "https://localhost:44330/";        

        #region "Get Menu List For Customer"
        public MenuAccessModel GetMenu(string CustomerId, bool IsAccess, string token)
        {
            try
            {
                MenuAccessModel Menu = new MenuAccessModel();
                
                HttpClient HC = new HttpClient();
                HC.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var Record = HC.GetAsync(Baseurl + "api/Menu/all/" + CustomerId + "/" + IsAccess);

                Record.Wait();

                var results = Record.Result;

                if (results.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Menu.status = "Unauthorized";
                }
                else if(results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    Menu = JsonConvert.DeserializeObject<MenuAccessModel>(UserResponse);
                    Menu.status = "Success";
                }

                HC.Dispose();
                return Menu;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion        
    }
}
