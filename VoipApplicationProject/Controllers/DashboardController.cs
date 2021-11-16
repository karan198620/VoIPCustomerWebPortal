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
    public class DashboardController : Controller
    {
        private readonly IDashboardRepo repo;
        public DashboardController(IDashboardRepo _repo)
        {
            repo = _repo;
        }

        #region "Index"

        [HttpGet]
        public IActionResult Index()
        {
            if (String.IsNullOrEmpty(GetCookie("CustomerId")))
            {
                return RedirectToAction("Login", "Customer");
            }
            else
            {
                MenuAccessModel Menu = repo.GetMenu(GetCookie("CustomerId"), true,GetCookie("token"));

                if (Menu.status == "Unauthorized")
                {
                   return RedirectToAction("Login", "Customer");
                }
                else if ((Menu.status == "Success") && (Menu.data.ToList().Count > 0))
                {
                    List<MenuAccessModel> MenuList = Menu.data.ToList();

                    var menus = MenuList;
                    ViewBag.menuList = menus.ToList();
                }
            }

            return View();
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
