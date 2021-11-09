using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        const string CustomerId = "";
        public DashboardController(IDashboardRepo _repo)
        {
            repo = _repo;
        }

        #region "Index"
        public IActionResult Index()
        {
            string CustId =  HttpContext.Session.GetString(CustomerId);
            List<MenuAccessModel> MenuList = repo.GetMenu(CustId, true);
            
            if (MenuList.Count > 0)
            {
                //if (MenuList[0].ToString() != "DashboardUsers")
                //{
                //    var menus = MenuList;
                //    ViewBag.menuList = menus.ToList();
                //}                
            }

            return View();
        }
        #endregion
    }
}
