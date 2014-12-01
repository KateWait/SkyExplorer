using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using SkyExplorer1.DAL;
using SkyExplorer1.Models;

namespace SkyExplorer1.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterPrivateUser(User user)
        {
            using (var context = new SkyContext())
            {
                user.CreatedAccount = DateTime.Now;
                user.BirthdayDate = DateTime.Now;
                context.Users.Add(user);
                context.SaveChanges();
            }
            TempData["Registration"] = "Yes";
            return RedirectToAction("LogIn", "Home");
        }

    }
}
