using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VoipApplicationProject.Models;
using VoipApplicationProject.Repositories;
using static VoipApplicationProject.RootObjects.RootObject;

namespace VoipApplicationProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo repo;
        public CustomerController(ICustomerRepo _repo)
        {
            repo = _repo;
        }

        #region "Get All Customers / Get All Existing Users"
        public IActionResult Index()
        {
            List<RootCustomer> CustomerList = repo.GetAllCustomers();
            ViewBag.ShowAlert = false;

            if (CustomerList.Count > 0)
            {
                return View(CustomerList);
            }
            else
            {
                return ViewBag.ShowAlert = true;
            }
        }
        #endregion

        #region "Sign Up"
        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.ShowAlert = "";
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(CustomerModel CM)
        {
            RootCustomer Customer = repo.Register(CM);

            if (Customer.userid != null)
            {
                if (repo.CreateMenuAccess(Customer.userid))
                {
                    return RedirectToAction("Login", "Customer");
                }
                else
                {
                    repo.DeleteCustomer(Customer.id);
                    ViewBag.ShowAlert = "menu_error";
                    return View();
                }
            }
            else
            {
                ViewBag.ShowAlert = Customer.message.ToString();
                return View();
            }
        }
        #endregion

        #region "Login"
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.ShowAlert = "";
            return View();
        }

        [HttpPost]
        public IActionResult Login(CustomerModel customer)
        {
            CustomerModel Customer = repo.IsAuthenticated(customer);

            if (Customer.IsAuthenticated == true)
            {
                if(Customer.CustomerTypeID == customer.CustomerTypeID)
                {                    
                    SetCookie("CustomerId", Customer.Id, 60);
                    SetCookie("token", Customer.token, 60);

                    string isRememberMe = Request.Form["ChkRememberMe"];

                    if(isRememberMe != "false")
                    {
                        SetCookie("refreshtoken", Customer.refreshtoken, 600);
                    }                   

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.ShowAlert = "customertype_error";
                    return View();
                }
            }
            else
            {
                ViewBag.ShowAlert = "login_error";
                return View();
            }

        }
        #endregion

        #region "Forgot Password"
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            ViewBag.ShowAlert = "";
            return View();
        }

        [HttpPost]
        [ActionName("ForgotPassword")]
        public ActionResult ForgotPasswordPost()
        {
            string email = Request.Form["Email"];

            if (repo.ForgotPassword(email))
            {
                ViewBag.ShowAlert = "success";
            }
            else
            {
                ViewBag.ShowAlert = "failed";
            }
            return View();
        }
        #endregion

        #region "Reset Password"
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(CustomerModel customerModel)
        {

            return View();
        }
        #endregion

        #region "Set Cookies"
        public void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            var encodedValue = Encoding.UTF8.GetBytes(value);
            var validValue = WebEncoders.Base64UrlEncode(encodedValue);

            Response.Cookies.Append(key, validValue, option);
        }
        #endregion
    }
}
