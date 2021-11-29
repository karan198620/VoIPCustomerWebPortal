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
    public class CustomerRepo : ICustomerRepo
    {
        string Baseurl = "https://localhost:44330/";

        #region "Get All Customers - Lucky"
        public List<CustomerModel> GetAllCustomers()
        {
            string api = "api/Account/getall";
            var result = CallingApi(true, api, true);
            return result.Item2.ToList();
        }
        #endregion

        #region "IsAuthenticated - Anagha"
        public CustomerModel IsAuthenticated(CustomerModel customer)
        {
            string api = "api/Account/authenticate";
            var result = CallingApi(false, api, false, customer);
            return result.Item1;
        }
        #endregion

        #region "Register - Jaideep"
        public CustomerModel Register(CustomerModel customer)
        {
            customer.CustomerName = customer.UserName;
            customer.CustomerTypeID = customer.CustomerTypeID == CustomerType.User ? CustomerType.User : customer.CustomerTypeID;
            customer.ISMigrated = false;
            customer.ISTrialBalanceOpted = customer.CustomerTypeID == CustomerType.Demo ? false : true;
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;

            string api = "api/Account/register";
            var result = CallingApi(false, api, false, customer);
            return result.Item1;
        }
        #endregion

        #region "Create Menu Access - Anagha"
        public bool CreateMenuAccess(string CustomerId,string CustomerType)
        {
            bool FunctionReturnValue = false;

            try
            {
                HttpClient HC = new HttpClient();
                HC.BaseAddress = new Uri(Baseurl);
                List<MenuAccessModel> menuItemList = new List<MenuAccessModel>();

                foreach (MenuLink menuLinkenum in (MenuLink[])Enum.GetValues(typeof(MenuLink)))
                {
                    if (CustomerType == "Users" && menuLinkenum == MenuLink.DashboardUsers)
                        continue;

                    if ((CustomerType == "Agents" && menuLinkenum == MenuLink.DashboardUsers) || (CustomerType == "Agents" && menuLinkenum == MenuLink.Billing))
                        continue;

                    if ((CustomerType == "DemoUsers" && menuLinkenum == MenuLink.DashboardUsers) || 
                        (CustomerType == "DemoUsers" && menuLinkenum == MenuLink.Link9) ||
                        (CustomerType == "DemoUsers" && menuLinkenum == MenuLink.Link10) ||
                        (CustomerType == "DemoUsers" && menuLinkenum == MenuLink.Link11) || 
                        (CustomerType == "DemoUsers" && menuLinkenum == MenuLink.DashboardAdminUsers))
                        continue;

                    menuItemList.Add(
                                    new MenuAccessModel()
                                    {
                                        CreatedAt = DateTime.Now,
                                        CustomerID = CustomerId,
                                        IsAccess = true,
                                        MenuLink = menuLinkenum,
                                        UpdatedAt = DateTime.Now
                                    });

                    if (CustomerType == "Users" && menuLinkenum == MenuLink.DashboardURL)
                        break;

                    if (CustomerType == "Agents" && menuLinkenum == MenuLink.ManageCallHistory)
                        break;
                }

                var insertedRecord = HC.PostAsJsonAsync("api/Menu", menuItemList);
                insertedRecord.Wait();

                var result = insertedRecord.Result;

                if (result.IsSuccessStatusCode)
                {
                    FunctionReturnValue = true;
                }
              
                HC.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return FunctionReturnValue;
        }
        #endregion

        #region "Delete Customer - Anagha"
        public void DeleteCustomer(string CustomerId)
        {
            try
            {
                HttpClient HC = new HttpClient();
                HC.BaseAddress = new Uri(Baseurl);

                var deletedRecord = HC.DeleteAsync("api/Account/delete/" + CustomerId);
                deletedRecord.Wait();

                HC.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Forgot Password - Krunal"       
        public bool ForgotPassword(string Email)
        {
            bool FunctionReturnValue = true;
            string api = "api/Account/ForgetPassword";

            CustomerModel cus = new CustomerModel();
            cus.Email = Email;
            var result = CallingApi(false, api, false, cus);

            if (result.Item1.Message == null)
                return FunctionReturnValue = false;
            else
                return FunctionReturnValue;
        }
        #endregion

        #region "Reset Password - Krunal"       
        public bool ResetPassword(CustomerModel customer)
        {
            bool FunctionReturnValue = true;
            string api = "api/Account/ResetPassword";
            var result = CallingApi(false, api, false, customer);

            if (result.Item1.Message == null)
                return FunctionReturnValue = false;
            else
                return FunctionReturnValue;
        }
        #endregion

        #region "Create Trial Balance Request Customers - Lucky"
        public bool CreateTrialBalanceCustomers(string CustomerId)
        {
            bool FunctionReturnValue = false;

            try
            {
                HttpClient HC = new HttpClient();
                HC.BaseAddress = new Uri(Baseurl);

                TrialBalanceRequestModel tbrModel = new TrialBalanceRequestModel();
                tbrModel.CustomerId = CustomerId;
                tbrModel.Date = DateTime.Now;
                tbrModel.TransactionType = TransactionType.credit;
                tbrModel.CreatedAt = DateTime.Now;
                tbrModel.UpdatedAt = DateTime.Now;
                tbrModel.Amount = 500;

                var insertedRecord = HC.PostAsJsonAsync("api/TrailBalanceCustomer", tbrModel);
                insertedRecord.Wait();

                var result = insertedRecord.Result;

                if (result.IsSuccessStatusCode)
                {
                    FunctionReturnValue = true;
                }

                HC.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return FunctionReturnValue;
        }
        #endregion

        #region "Manage Call Recording - Krunal"
        public List<CallRecordingModel> GetAllCallRecordings(string CustomerId)
        {
            try
            {
                CallRecordingModel result = new CallRecordingModel();
                List<CallRecordingModel> GetAllCallRecordings = new List<CallRecordingModel>();

                HttpClient HC = new HttpClient();
                var insertedRecord = HC.GetAsync(Baseurl + "api/CallRecordingAgent/GetAll/" + CustomerId);

                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<CallRecordingModel>(UserResponse);
                    GetAllCallRecordings = result.data.ToList();
                }

                HC.Dispose();
                return GetAllCallRecordings;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Get Subscription List - Jaideep"
        public List<SubscriptionModel> GetSubscriptionList(string CustomerId)
        {
            try
            {
                SubscriptionModel result = new SubscriptionModel();
                List<SubscriptionModel> GetSubscriptionList = new List<SubscriptionModel>();

                HttpClient HC = new HttpClient();
                var insertedRecord = HC.GetAsync(Baseurl + "api/SubscriptionCustomer/" + CustomerId);

                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<SubscriptionModel>(UserResponse);
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

        #region "Common Method For Calling API - Anagha"
        public Tuple<CustomerModel, List<CustomerModel>> CallingApi(bool IsGet, string api, bool IsList, CustomerModel customer = null)
        {
            try
            {
                HttpClient HC = new HttpClient();
                CustomerModel customermodel = new CustomerModel();
                List<CustomerModel> customermodelList = new List<CustomerModel>();

                var Record = IsGet ? HC.GetAsync(Baseurl + api) : HC.PostAsJsonAsync(Baseurl + api, customer);
                Record.Wait();

                var results = Record.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;

                    if (!IsList)
                        customermodel = JsonConvert.DeserializeObject<CustomerModel>(UserResponse);
                    else
                        customermodelList = JsonConvert.DeserializeObject<List<CustomerModel>>(UserResponse);
                }

                HC.Dispose();
                return Tuple.Create(customermodel, customermodelList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
