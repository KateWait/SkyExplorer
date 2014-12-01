using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

using SkyExplorer1.FactoryMethod;
using SkyExplorer1.Builder;

namespace SkyExplorer1.Facade
{
    public class Fasada
    {
        internal MySqlCreator creator = new MySqlCreator();
        internal MSSqlCreator creator2 = new MSSqlCreator();
        internal Producer p = new Producer();

        public DataTable GetMysqlScheme(string ServerName, string DatabaseName, string UserName, string Password, string PortNumber = "", string UseSSL = "", string ActivateSSL = "")
        {         
            creator = new MySqlCreator();
            return creator.SchemeFactory(GetMySqlConnectionString(ServerName, DatabaseName, UserName, Password, PortNumber, UseSSL, ActivateSSL));
        }

        public string GetMySqlConnectionString(string ServerName, string DatabaseName, string UserName, string Password, string PortNumber = "", string UseSSL = "", string ActivateSSL = "")
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Server", ServerName);
            dict.Add("Database", DatabaseName);
            dict.Add("Port", PortNumber);
            dict.Add("Uid", UserName);
            dict.Add("Pwd", Password);

            
            StringBuilder2 s = new MySqlConnectionStringBUilder(dict);
            p.SetBuilder(s);
            p.CreateConnectionString();

            return s.StringC;
        }

        public DataTable GetSMySqlelectedTable(string conn, string tableName)
        {
            return creator.SelectFactory(conn, tableName);
        }

        public DataTable GetMSsqlScheme(string ServerName, string DatabaseName, string UserName, string Password, string Trusted)
        {
            return creator2.SchemeFactory(GetMSSqlConnectionString(ServerName, DatabaseName, UserName, Password, Trusted));
        }

        public string GetMSSqlConnectionString(string ServerName, string DatabaseName, string UserName, string Password, string Trusted)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Server", ServerName);
            dict.Add("Database", DatabaseName);
            dict.Add("User Id", UserName);
            dict.Add("Password", Password);
            dict.Add("Trusted_Connection", Trusted);

            StringBuilder2 s = new MSSqlConnectionStringBUilder(dict);
            p.SetBuilder(s);
            p.CreateConnectionString();

            return s.StringC;
        }

        public DataTable GetSMSSqlelectedTable(string conn, string tableName)
        {
            return creator2.SelectFactory(conn, tableName);
        }

        public DataTable GetSMSSqlelectedTopTable(string top, string conn, string tableName)
        {
            return creator2.SelectTopFactory(top, conn, tableName);
        }

        public DataTable GetSMySqlelectedTopTable(string top, string conn, string tableName)
        {
            return creator.SelectTopFactory(top, conn, tableName);
        }
    }
}