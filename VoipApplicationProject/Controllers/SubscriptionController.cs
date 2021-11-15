using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoipApplicationProject.Models;
using VoipApplicationProject.Repositories;

namespace VoipApplicationProject.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionRepo repo;
        const string CustomerId = "";
        public SubscriptionController(ISubscriptionRepo _repo)
        {
            repo = _repo;
        }
       
        #region " Get allSubscription"
        [HttpGet]
        public IActionResult Index()
        {

            string customerId =GetCookie("CustomerId");
            List<SubscriptionModel> allsubscription = repo.GetSubscriptionList(customerId);
            if (allsubscription.Count > 0)
            {
                return View(allsubscription);
            }
            else
            {
                return RedirectToAction("Login", "Customer");
            }
        }
        [HttpPost]
        public IActionResult Index(CustomerModel customerModel)
        {

            return View("Index","Subscription");

        }
        #endregion

        #region "Get Cookies"
        public string GetCookie(string Value)
        {
            var decodedValue = WebEncoders.Base64UrlDecode(Request.Cookies[Value]);
            string normalValue = Encoding.UTF8.GetString(decodedValue);

            return normalValue;
        }
        #endregion

    }



}