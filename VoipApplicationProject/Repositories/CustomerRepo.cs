using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VoipApplicationProject.Models;
using static VoipApplicationProject.RootObjects.RootObject;

namespace VoipApplicationProject.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        string Baseurl = "https://localhost:44330/";

        #region "Get All Customers"
        public List<RootCustomer> GetAllCustomers()
        {
            string api = "api/Account/getall";
            try
            {
                HttpClient HC = new HttpClient();
                List<RootCustomer> result = new List<RootCustomer>();


                var insertedRecord = HC.GetAsync(Baseurl + api);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<RootCustomer>>(UserResponse);
                }

                HC.Dispose();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "IsAuthenticated - Anagha"
        public CustomerModel IsAuthenticated(CustomerModel customer)
        {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                RootCustomer result = new RootCustomer();

                HttpClient HC = new HttpClient();
                HC.BaseAddress = new Uri(Baseurl);

                var insertedRecord = HC.PostAsJsonAsync("api/Account/authenticate", customer);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RootCustomer>(UserResponse);

                    customerModel = new CustomerModel
                    {
                        Email = result.email,
                        Id = result.id,
                        UserName = result.userName,
                        token = result.token,
                        refreshtoken = result.refreshToken,
                        IsAuthenticated = result.isAuthenticated,
                        CustomerTypeID = result.CustomerTypeId
                    };
                }

                HC.Dispose();
                return customerModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Validate Email"
        public string ValidateEmail(string Email)
        {
            var CustomerEmail = "";
            try
            {
                HttpClient HC = new HttpClient();
                RootCustomer result = new RootCustomer();

                var insertedRecord = HC.GetAsync(Baseurl + "api/Account/findemail/" + Email);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RootCustomer>(UserResponse);
                    CustomerEmail = result.email.ToString();
                }

                HC.Dispose();
                return CustomerEmail;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Register"
        public RootCustomer Register(CustomerModel customer)
        {
            customer.CustomerName = customer.UserName;
            customer.CustomerTypeID = CustomerType.User;
            customer.ISMigrated = false;
            customer.ISTrialBalanceOpted = true;
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;

            try
            {
                HttpClient HC = new HttpClient();
                HC.BaseAddress = new Uri(Baseurl);
                RootCustomer result = new RootCustomer();

                var insertedRecord = HC.PostAsJsonAsync("api/Account/register", customer);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RootCustomer>(UserResponse);
                }

                HC.Dispose();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Create Menu Access"
        public bool CreateMenuAccess(string CustomerId)
        {
            bool FunctionReturnValue = false;

            try
            {
                HttpClient HC = new HttpClient();
                HC.BaseAddress = new Uri(Baseurl);
                MenuAccessModel menu = new MenuAccessModel();

                //foreach (MenuLink menuLinkenum in (MenuLink[])Enum.GetValues(typeof(MenuLink)))
                //{

                //}

                menu.CustomerID = CustomerId;
                menu.MenuLink = MenuLink.DashboardUsers;
                menu.CreatedAt = DateTime.Now;
                menu.UpdatedAt = DateTime.Now;
                menu.IsAccess = true;

                var insertedRecord = HC.PostAsJsonAsync("api/Menu", menu);
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

        #region "Delete Customer"
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

        #region "Get Customer By Id"
        public CustomerModel GetCustomerById(string CustomerId)
        {
            try
            {
                CustomerModel customer = new CustomerModel();

                HttpClient HC = new HttpClient();
                Root result = new Root();

                var insertedRecord = HC.GetAsync(Baseurl + "api/Customer/" + CustomerId);

                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<Root>(UserResponse);
                    customer = result.data;
                }

                HC.Dispose();
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Forgot Password"       
        public bool ForgotPassword(string Email)
        {
            bool FunctionReturnValue = false;
            try
            {
                HttpClient HC = new HttpClient();
                HC.BaseAddress = new Uri(Baseurl);
                RootCustomer result = new RootCustomer();
               
                var insertedRecord = HC.PostAsJsonAsync("api/Account/ForgetPassword", Email);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RootCustomer>(UserResponse);

                    FunctionReturnValue = true;
                }

                HC.Dispose();
                return FunctionReturnValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Reset Password"       
        public bool ResetPassword(ResetPasswordModel customer)
        {
            bool FunctionReturnValue = false;
            try
            {
                HttpClient HC = new HttpClient();
                HC.BaseAddress = new Uri(Baseurl);
                CustomerModel result = new CustomerModel();

                var insertedRecord = HC.PostAsJsonAsync("api/Account/ResetPassword", customer);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<CustomerModel>(UserResponse);

                    FunctionReturnValue = true;
                }

                HC.Dispose();
                return FunctionReturnValue;
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
            public CustomerModel[] data { get; set; }
        }

        public class Root
        {
            public string status { get; set; }
            public CustomerModel data { get; set; }
        }
        #endregion
    }
}
