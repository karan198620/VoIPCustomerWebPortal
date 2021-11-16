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
            customer.CustomerTypeID = CustomerType.User;
            customer.ISMigrated = false;
            customer.ISTrialBalanceOpted = true;
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
                    if (CustomerType == "Agents" && menuLinkenum == MenuLink.DashboardUsers || menuLinkenum == MenuLink.Billing)
                        continue;

                    if (CustomerType == "DemoUsers" && menuLinkenum == MenuLink.DashboardUsers || menuLinkenum == MenuLink.Link9
                        || menuLinkenum == MenuLink.Link10 || menuLinkenum == MenuLink.Link11 || menuLinkenum == MenuLink.DashboardAdminUsers)
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
