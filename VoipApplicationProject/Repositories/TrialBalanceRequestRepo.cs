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
    public class TrialBalanceRequestRepo : ITrialBalanceRequestRepo
    {
        string Baseurl = "https://localhost:44330/";

        #region "Get All Trial Balance Request - Anagha"
        public TrialBalanceRequestModel GetAllRequest(string token)
        {
            try
            {
                TrialBalanceRequestModel TBRModel = new TrialBalanceRequestModel();

                HttpClient HC = new HttpClient();
                HC.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var Record = HC.GetAsync(Baseurl + "api/TrailBalanceCustomer");

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
                    TBRModel.status = "Success";
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
