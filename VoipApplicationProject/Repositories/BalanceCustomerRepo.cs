using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VoipApplicationProject.Models;
using static VoipApplicationProject.Repositories.SubscriptionRepo;

namespace VoipApplicationProject.Repositories
{
    public class BalanceCustomerRepo : IBalanceCustomerRepo
    {
        string Baseurl = "https://localhost:44330/";
        public List<BalanceCustomerModel> GetBalanceCustomerList(string CustomerId)
        {
            try
            {
                List<BalanceCustomerModel> GetSubscriptionList = new List<BalanceCustomerModel>();

                HttpClient HC = new HttpClient();
                RootObject result = new RootObject();

                var insertedRecord = HC.GetAsync(Baseurl + "api/BalanceCustomer/" + CustomerId);

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
            ///throw new NotImplementedException();
        }

        public class RootObject
        {
            public string status { get; set; }
            public string userid { get; set; }
            public BalanceCustomerModel[] data { get; set; }


        }
    }
}
