using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseExplorer.ViewModels;
using SkyExplorer1.Facade;
using System.Data;

namespace SkyExplorer1.Controllers
{
    public class MSSqlController : Controller
    {
        //
        // GET: /MSSql/
        private Fasada facade;

        public ActionResult Index()
        {
            return View("MSSql");
        }

        [HttpPost]
        public ActionResult GetScheme(string ServerName, string DatabaseName, string UserName, string Password, string Trusted)
        {
            facade = new Fasada();
            DataTable dt = facade.GetMSsqlScheme(ServerName, DatabaseName, UserName, Password, Trusted);

            HomeViewModel vm = new HomeViewModel(dt, facade.GetMSSqlConnectionString(ServerName, DatabaseName, UserName, Password, Trusted));
            return View("Scheme", vm);
        }

        public ActionResult Select(string tableName, string connectionString)
        {
            facade = new Fasada();
            DataTable dt = facade.GetSMSSqlelectedTable(connectionString, tableName);

            HomeViewModel vm = new HomeViewModel(dt, connectionString, tableName);
            return PartialView("Selected", vm);
        }

        public ActionResult SelectTop(string top, string connectionString, string tableName)
        {
            facade = new Fasada();
            var dt = facade.GetSMSSqlelectedTopTable(top, connectionString, tableName);

            var vm = new HomeViewModel(dt, connectionString, tableName);
            return PartialView("Selected", vm);
        }

        public ActionResult TestConnection(string ServerName, string DatabaseName, string UserName, string Password, string Trusted)
        {
            try
            {
                facade = new Fasada();
                var dt = facade.GetMSsqlScheme(ServerName, DatabaseName, UserName, Password, Trusted);
                @TempData["TestData"] = 1;
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                //log error
                @TempData["TestData"] = exception.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
