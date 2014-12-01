using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseExplorer.ViewModels;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using SkyExplorer1.DAL;
using SkyExplorer1.Facade;
using System.Text;
using SkyExplorer1.Models;

namespace SkyExplorer1.Controllers
{
    public class MySqlController : Controller
    {
        //
        // GET: /MySql/
        Fasada facade;
        public ActionResult Index()
        {
            return View("MysqlConnection");
        }

        [HttpPost]
        public ActionResult GetScheme(string ServerName, string DatabaseName, string UserName, string Password, string PortNumber = "", string UseSSL = "", string ActivateSSL = "" )
        {
            facade = new Fasada();
            DataTable dt = facade.GetMysqlScheme(ServerName, DatabaseName, UserName, Password, PortNumber, UseSSL, ActivateSSL);

            HomeViewModel vm = new HomeViewModel(dt, facade.GetMySqlConnectionString(ServerName, DatabaseName, UserName, Password, PortNumber, UseSSL, ActivateSSL));
            return View("Scheme", vm);
        }

        public ActionResult Select(string tableName, string connectionString)
        {
            facade = new Fasada();
            DataTable dt =  facade.GetSMySqlelectedTable(connectionString, tableName);

            HomeViewModel vm = new HomeViewModel(dt, connectionString, tableName);
            return PartialView("Selected", vm);
        }

        public ActionResult SelectTop(string top, string connectionString, string tableName)
        {
            facade = new Fasada();
            DataTable dt = facade.GetSMySqlelectedTopTable(top, connectionString, tableName);

            HomeViewModel vm = new HomeViewModel(dt, connectionString, tableName);
            return PartialView("Selected", vm);
        }

        public ActionResult TestConnection(string ServerName, string DatabaseName, string UserName, string Password,
            string PortNumber = "", string UseSSL = "", string ActivateSSL = "")
        {
            try
            {
                facade = new Fasada();
                var dt = facade.GetMysqlScheme(ServerName, DatabaseName, UserName, Password, PortNumber, UseSSL, ActivateSSL);
                @TempData["TestData"] = "OK";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                //log error
                @TempData["TestData"] = exception.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult SaveConnection(string ServerName, string DatabaseName, string UserName, string Password,
            string PortNumber = "", string UseSSL = "", string ActivateSSL = "")
        {
           facade = new Fasada();
            try
            {
                facade = new Fasada();
                var dt = facade.GetMysqlScheme(ServerName, DatabaseName, UserName, Password, PortNumber, UseSSL, ActivateSSL);
               
                var connectionString = facade.GetMySqlConnectionString(ServerName, DatabaseName, UserName, Password,
                    PortNumber, UseSSL, ActivateSSL);

                using (var context = new SkyContext())
                {
                    var dataBaseType =
                        context.DatabaseTypes.Where(a => a.DatabaseTypeID == 1).Select(a => a).FirstOrDefault();
                    connectionString += "[1]";
                    context.ConnectionStrings.Add(new ConnectionString()
                    {
                        Connection = connectionString,
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                //log error
                @TempData["TestData"] = exception.Message;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
