using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VoipApplicationProject.Models;
using VoipApplicationProject.Repositories;

namespace VoipApplicationProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo repo;
        const string CustomerId = "";
        public CustomerController(ICustomerRepo _repo)
        {
            repo = _repo;
        }

        #region "Get All Customers / Get All Existing Users"
        public IActionResult Index()
        {
            List<CustomerModel> CustomerList = repo.GetAllCustomers();
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
        public IActionResult SignUp(CustomerModel customer)
        {
            string Email = repo.ValidateEmail(customer.Email);

            if (!String.IsNullOrEmpty(Email))
            {
                ViewBag.ShowAlert = "email_error";
                return View();
            }
            else
            {
                string userid = repo.Register(customer);

                if (userid != null)
                {
                    if (repo.CreateMenuAccess(userid))
                    {
                        return RedirectToAction("Login", "Customer");
                    }
                    else
                    {
                        //repo.DeleteCustomer(Cust.Email);
                        ViewBag.ShowAlert = "menu_error";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ShowAlert = "signup_error";
                    return View();
                }
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
            //int custTypeid = repo.GetEnumValue(Convert.ToString(customer.CustomerTypeID));

            CustomerModel Customer = repo.IsAuthenticated(customer);

            if (Customer.IsAuthenticated == true)
            {
                if(Customer.CustomerTypeID == customer.CustomerTypeID)
                {
                    CustomerModel Customers = repo.GetCustomerById(Customer.Id);
                    HttpContext.Session.SetString(CustomerId, Customer.Id);

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
            ViewBag.ShowAlert = false;
            return View();
        }

        [HttpPost]
        [ActionName("ForgotPassword")]
        public ActionResult ForgotPasswordPost()
        {
            string email = Request.Form["Email"];

            string CustomerEmail = repo.ValidateEmail(email);

            if (!String.IsNullOrEmpty(CustomerEmail))
            {
                SendEmail sm = new SendEmail();
                string Body = "Click link below to Reset Password \n\n https://localhost:44314/Customer/ResetPassword";
                sm.SendEmailTo(CustomerEmail, Body);

                ViewBag.message = "Link Has beeen send to Registered Email";
                return View();
                //return RedirectToAction("Home", "Index");
            }
            else
            {
                ViewBag.ShowAlert = true;
                return View();
            }
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
    }
}
