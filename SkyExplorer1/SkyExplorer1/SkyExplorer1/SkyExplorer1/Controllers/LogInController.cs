using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkyExplorer1.DAL;
using SkyExplorer1.Models;

namespace SkyExplorer1.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(Credentials credentials)
        {
            using (var context = new SkyContext())
            {
                var user =
                    context.Users.Where(
                        a =>
                            (a.Email.Equals(credentials.Login) ||
                             a.Login.Equals(credentials.Login) && a.Password.Equals(credentials.Password)))
                        .Select(a => a).FirstOrDefault();
                if (user != null)
                {
                    Session["UserId"] = user;
                    return RedirectToAction("AdminMainPage", "Admin");
                }
                TempData["LogIn"] = "No";
                return RedirectToAction("LogIn", "Home");
            }
        }

    }
}
