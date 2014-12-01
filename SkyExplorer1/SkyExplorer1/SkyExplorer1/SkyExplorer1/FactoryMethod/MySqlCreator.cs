using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace SkyExplorer1.FactoryMethod
{
    public class MySqlCreator : ICreator
    {
        public System.Data.DataTable SchemeFactory(string conn)
        {
            MySql m = new MySql(conn);
            return m.GetScheme();
        }

        public DataTable SelectFactory(string conn, string tableName)
        {
            MySql m = new MySql(conn, tableName);
            return m.GetSelect();
        }


        public DataTable SelectTopFactory(string top, string conn, string tableName)
        {
            string query = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TOP ");
            sb.Append(top);
            sb.Append(" * FROM ");
            sb.Append(tableName);
            query = sb.ToString();
            MSSql m = new MSSql(conn, tableName);
            return m.GetSelect(query);
        }
    }
}