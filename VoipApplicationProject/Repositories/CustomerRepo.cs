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

        #region "Get Customer Type Enum Value"
        //public int GetEnumValue(string Type)
        //{
        //    int enumInt = (int)Enum.Parse(typeof(CustomerType), Type);
        //    return enumInt;
        //}
        #endregion

        #region "Get All Customers"
        public List<CustomerModel> GetAllCustomers()
        {
            string api = "api/Customer";
            List<CustomerModel> CustomerList = GetCustomerList(api);

            return CustomerList;
        }
        #endregion

        #region "Validate Login"
        public CustomerModel IsAuthenticated(CustomerModel customer)
        {
            //string api = "api/Customer/ValidateLogin/" + customer.CustomerName + "/" + customer.Password;
            try
            {
                CustomerModel customerModel = new CustomerModel();
                CustomerRoot result = new CustomerRoot();

                HttpClient HC = new HttpClient();
                //HC.BaseAddress = new Uri(Baseurl);                

                var insertedRecord = HC.PostAsJsonAsync("https://localhost:44330/api/Account/authenticate?api-version=1.0", customer);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<CustomerRoot>(UserResponse);

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
                CustomerRoot result = new CustomerRoot();

                var insertedRecord = HC.GetAsync(Baseurl + "api/Account/findemail/" + Email);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<CustomerRoot>(UserResponse);
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

        #region "Create Customer"
        public string Register(CustomerModel customer)
        {
            customer.UserName = customer.CustomerName;
            customer.CustomerTypeID = CustomerType.User;
            customer.ISMigrated = false;
            customer.ISTrialBalanceOpted = true;
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;

            try
            {
                //CustomerModel CM = new CustomerModel();
                string userid = "";
                HttpClient HC = new HttpClient();
                HC.BaseAddress = new Uri(Baseurl);
                CustomerRoot result = new CustomerRoot();

                var insertedRecord = HC.PostAsJsonAsync("api/Account/register", customer);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<CustomerRoot>(UserResponse);
                    userid = result.userid;
                }

                HC.Dispose();
                return userid;
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
        public void DeleteCustomer(string email)
        {
            //string CustomerList = ValidateEmail(email);

            //if(CustomerList.Count > 0)
            //{
            //    try
            //    {
            //        HttpClient HC = new HttpClient();
            //        HC.BaseAddress = new Uri(Baseurl);

            //        var insertedRecord = HC.DeleteAsync("api/Customer/" + CustomerList[0].CustomerId);
            //        insertedRecord.Wait();

            //        HC.Dispose();
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}
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

        #region "Common Method - Get Customer List"
        public List<CustomerModel> GetCustomerList(string api)
        {
            try
            {
                List<CustomerModel> CustomerList = new List<CustomerModel>();

                HttpClient HC = new HttpClient();
                RootObject result = new RootObject();


                var insertedRecord = HC.GetAsync(Baseurl + api);
                insertedRecord.Wait();

                var results = insertedRecord.Result;

                if (results.IsSuccessStatusCode)
                {
                    var UserResponse = results.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RootObject>(UserResponse);
                    CustomerList = result.data.ToList();
                }

                HC.Dispose();
                return CustomerList;
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

        public class CustomerRoot
        {
            public string status { get; set; }
            public string userid { get; set; }
            public string email { get; set; }
            public bool isAuthenticated { get; set; }
            public string id { get; set; }
            public CustomerType CustomerTypeId { get; set; }
            public string userName { get; set; }
            public string token { get; set; }
            public string refreshToken { get; set; }
            public string refreshTokenExpiration { get; set; }
        }
        #endregion
    }
}
