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
            List<CustomerModel> CustomerList = repo.ValidateEmail(customer.Email);

            if (CustomerList.Count > 0)
            {
                ViewBag.ShowAlert = "email_error";
                return View();
            }
            else
            {
                CustomerModel Cust = repo.CreateCustomer(customer);

                if (Cust != null)
                {
                    if (repo.CreateMenuAccess(Cust.CustomerId))
                    {
                        return RedirectToAction("Login", "Customer");
                    }
                    else
                    {
                        repo.DeleteCustomer(Cust.Email);
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

            List<CustomerModel> CustomerList = repo.ValidateLogin(customer);

            if (CustomerList.Count > 0)
            {
                if(CustomerList[0].CustomerTypeID == customer.CustomerTypeID)
                {
                    CustomerModel Customer = repo.GetCustomerById(CustomerList[0].CustomerId);
                    HttpContext.Session.SetString(CustomerId, Customer.CustomerId);

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

            List<CustomerModel> CustomerList = repo.ValidateEmail(email);

            if (CustomerList.Count > 0)
            {
                SendEmail sm = new SendEmail();
                string Body = "Click link below to Reset Password \n\n https://localhost:44314/Customer/ResetPassword";
                sm.SendEmailTo(CustomerList[0].Email, Body);

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

    }
}
