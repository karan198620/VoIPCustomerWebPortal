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
    public class BalanceCustomerController : Controller
    {

        private readonly IBalanceCustomerRepo repo;
        const string CustomerId = "";
        public BalanceCustomerController(IBalanceCustomerRepo _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public IActionResult Index()
        {

            string customerId = GetCookie("CustomerId");
            List<BalanceCustomerModel> alltranscation = repo.GetBalanceCustomerList(customerId);
            if (alltranscation.Count > 0)
            {
                return View(alltranscation);
            }
            else
            {
                return RedirectToAction("Login", "Customer");
            }
        }
        
        

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
