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
    public class TrailBalanceCustomerRepo : ITrailBalanceCustomerRepo
    {
        string Baseurl = "https://localhost:44330/";
        #region
        //public TrialBalanceRequestModel CallingApi(bool IsGet, string api, TrialBalanceRequestModel trialBalanceCustomer = null)
        //{
        //    try
        //    {
        //        HttpClient HC = new HttpClient();
        //        TrialBalanceRequestModel trailBalanceCustomerModel = new TrialBalanceRequestModel();

        //        var Record = IsGet ? HC.GetAsync(Baseurl + api) : HC.PostAsJsonAsync(Baseurl + api, trialBalanceCustomer);
        //        Record.Wait();

        //        var results = Record.Result;

        //        if (results.IsSuccessStatusCode)
        //        {
        //            var UserResponse = results.Content.ReadAsStringAsync().Result;
        //            //trailBalanceCustomerModel = JsonConvert.DeserializeObject<TrialBalanceRequestModel>(UserResponse);


        //        }
        //        HC.Dispose();
        //        return trailBalanceCustomerModel;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }


        //}
        #endregion
        public TrialBalanceRequestModel CallingApi(bool IsGet, string api, string token = "", TrialBalanceRequestModel trialBalanceCustomer = null)
        {
            try
            {
                HttpClient HC = new HttpClient();
                TrialBalanceRequestModel TBRModel = new TrialBalanceRequestModel();

                if (!String.IsNullOrEmpty(token))
                {
                    HC.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var Record = IsGet ? HC.GetAsync(Baseurl + api) : HC.PostAsJsonAsync(Baseurl + api, trialBalanceCustomer);
                Record.Wait();

                var results = Record.Result;


                if (results.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    TBRModel.status = "Unauthorized";
                }
                else if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;

                    TBRModel = JsonConvert.DeserializeObject<TrialBalanceRequestModel>(UserResponse);
                }

                HC.Dispose();
                return TBRModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TrialBalanceRequestModel CreateTrialBalanceCustomers(TrialBalanceRequestModel trialBalanceRequestModel)
        {
            string api = "api/TrailBalanceCustomer";
            var result = CallingApi(false, api,"", trialBalanceRequestModel);
            return result;
        }
    }
}
