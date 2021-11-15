using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VoipApplicationProject.Models;

namespace VoipApplicationProject.Repositories
{
    public class SubscriptionRepo : ISubscriptionRepo
    {
        string Baseurl = "https://localhost:44330/";
        #region "Get Subscription List For Customer"
        public List<SubscriptionModel> GetSubscriptionList(string CustomerId)
        {
            try
            {
                List<SubscriptionModel> GetSubscriptionList = new List<SubscriptionModel>();

                HttpClient HC = new HttpClient();
                RootObject result = new RootObject();

                var insertedRecord = HC.GetAsync(Baseurl + "api/SubscriptionCustomer/" + CustomerId);

                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RootObject>(UserResponse);
                    GetSubscriptionList = result.data.ToList();
                }

                HC.Dispose();
                return GetSubscriptionList;
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
            public string userid { get; set; }
            public SubscriptionModel[] data { get; set; }


        }
        #endregion
    }
}