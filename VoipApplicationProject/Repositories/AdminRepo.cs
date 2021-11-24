using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public List<TrialBalanceRequestModel> GetAllTBRRequest(string token, string fromDate = "", string toDate = "")
        {
            string api = "";

            if (!String.IsNullOrEmpty(fromDate) && !String.IsNullOrEmpty(toDate))
            {
                string[] formats = { "dd/MM/yyyy" };
                fromDate = (DateTime.ParseExact(fromDate, formats, new CultureInfo("en-US"))).ToString();
                toDate = (DateTime.ParseExact(toDate, formats, new CultureInfo("en-US"))).ToString();

                api = "api/TrailBalanceCustomer?fromDate=" + fromDate + "&toDate=" + toDate;
            }
            else
            {
                api = "api/TrailBalanceCustomer";
            }

            var result = CallingApi(true, api, token);

            List<TrialBalanceRequestModel> tbrList = new List<TrialBalanceRequestModel>();

            tbrList = result.data.ToList();

            for (int nCount = 0; nCount < result.data.Count(); nCount++)
            {
                var customer = GetCustomerById(result.data[nCount].CustomerId, token);

                tbrList[nCount].OrganisationName = customer.OrganisationName;
                tbrList[nCount].CustomerTypeId = customer.CustomerTypeId;
                tbrList[nCount].Email = customer.Email;                          
            }           

            return tbrList;
        }
        #endregion

        #region "Get Customer By Id - Anagha"
        public TrialBalanceRequestModel GetCustomerById(string Id, string token)
        {
            string api = "api/Account/getById?Id=" + Id;
            var result = CallingApi(true, api, token);
            return result;
        }
        #endregion

        #region "Common Method For Calling API - Anagha"
        public TrialBalanceRequestModel CallingApi(bool IsGet, string api, string token = "", CustomerModel customer = null)
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
