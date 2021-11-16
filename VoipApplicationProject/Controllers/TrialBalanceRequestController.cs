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
    public class TrialBalanceRequestController : Controller
    {
        private readonly ITrialBalanceRequestRepo repo;
        public TrialBalanceRequestController(ITrialBalanceRequestRepo _repo)
        {
            repo = _repo;
        }

        #region "Index"
        [HttpGet]
        public IActionResult Index()
        {
            TrialBalanceRequestModel TBRModel = repo.GetAllRequest(GetCookie("CustomerId"), GetCookie("token"));
            return View(TBRModel);
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
