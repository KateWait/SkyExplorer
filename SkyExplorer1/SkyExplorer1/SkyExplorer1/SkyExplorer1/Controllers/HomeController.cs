using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyExplorer1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult PrivateRegister()
        {
            return View();
        }

        public ActionResult CompanyRegister()
        {
            return View();
        }

    }
}
