using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VoipApplicationProject.Models;

namespace VoipApplicationProject.Repositories
{
    public class DashboardRepo : IDashboardRepo
    {
        string Baseurl = "https://localhost:44330/";        

        #region "Get Menu List For Customer"
        public List<MenuAccessModel> GetMenu(string CustomerId, bool IsAccess)
        {
            try
            {
                List<MenuAccessModel> MenuList = new List<MenuAccessModel>();

                HttpClient HC = new HttpClient();
                RootObject result = new RootObject();

                var insertedRecord = HC.GetAsync(Baseurl + "api/Menu/all/" + CustomerId + "/" + IsAccess);

                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RootObject>(UserResponse);
                    MenuList = result.data.ToList();                   
                }

                HC.Dispose();
                return MenuList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Root Object"
        public class RootObject
        {
            public string status { get; set; }
            public MenuAccessModel[] data { get; set; }
        }
        #endregion
    }
}
