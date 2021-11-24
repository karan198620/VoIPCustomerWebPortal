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
    public class AdminController : Controller
    {
        private readonly IAdminRepo repo;
        public AdminController(IAdminRepo _repo)
        {
            repo = _repo;
        }

        #region "Manage TrialBalanceRequest - Anagha"
        [HttpGet]
        public IActionResult ManageTrialBalanceRequest()
        {
            string token = GetCookie("token");
            if (!String.IsNullOrEmpty(token))
            {
                var result = repo.GetAllTBRRequest(token);
                TrialBalanceRequestModel TBRModel = new TrialBalanceRequestModel();
                TBRModel.data = result.ToArray();
                return View(TBRModel);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Customer");
            }
        }

        [HttpPost]
        public IActionResult ManageTrialBalanceRequest(TrialBalanceRequestModel trialBalanceRequestModel)
        {
            string token = GetCookie("token");
            if (!String.IsNullOrEmpty(token))
            {
                var result = repo.GetAllTBRRequest(token, trialBalanceRequestModel.FromDate, trialBalanceRequestModel.ToDate);
                
                if (!String.IsNullOrEmpty(trialBalanceRequestModel.IsRole))
                {
                    result = result.Where(item => item.CustomerTypeId == trialBalanceRequestModel.CustomerTypeId).ToList();
                }

                TrialBalanceRequestModel TBRModel = new TrialBalanceRequestModel();
                TBRModel.data = result.ToArray();
                return View(TBRModel);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Customer");
            }
        }
        #endregion

        #region "Get Cookies"
        public string GetCookie(string Value)
        {
            string cookieValue = "";
            if (!String.IsNullOrEmpty(Request.Cookies[Value]))
            {
                var decodedValue = WebEncoders.Base64UrlDecode(Request.Cookies[Value]);
                cookieValue = Encoding.UTF8.GetString(decodedValue);                
            }
            return cookieValue;
        }
        #endregion
    }
}
