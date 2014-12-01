using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SkyExplorer1.FactoryMethod
{
    public class MSSqlCreator : ICreator
    {
        public System.Data.DataTable SchemeFactory(string coon)
        {
            MSSql m = new MSSql(coon);
            return m.GetScheme();
        }

        public System.Data.DataTable SelectFactory(string conn, string tableName)
        {
            MSSql m = new MSSql(conn, tableName);
            return m.GetSelect();
        }

        public System.Data.DataTable SelectTopFactory(string top, string conn, string tableName)
        {
            string query = "SELECT * FROM Users ORDER BY username";

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