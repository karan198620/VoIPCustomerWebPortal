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
    public class AdminRepo : IAdminRepo
    {
        string Baseurl = "https://localhost:44330/";

        #region "Get All Trial Balance Request - Anagha"
        public TrialBalanceRequestModel GetAllTBRRequest(string token)
        {
            string api = "api/TrailBalanceCustomer";
            var result = CallingApi(true, api, token);
            return result;
        }
        #endregion

        #region "Get Customer By Id"
        public TrialBalanceRequestModel GetCustomerById(string Id,string token)
        {
            string api = "api/Account/getById/" + Id;
            var result = CallingApi(true, api, token);
            return result;
        }
        #endregion

        #region "Common Method For Calling API - Anagha"
        public TrialBalanceRequestModel CallingApi(bool IsGet, string api,string token = "", CustomerModel customer = null)
        {
            try
            {
                HttpClient HC = new HttpClient();
                TrialBalanceRequestModel TBRModel = new TrialBalanceRequestModel();
                
                if (!String.IsNullOrEmpty(token))
                {
                    HC.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var Record = IsGet ? HC.GetAsync(Baseurl + api) : HC.PostAsJsonAsync(Baseurl + api, customer);
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
        #endregion
    }
}
