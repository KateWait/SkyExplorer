using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SkyExplorer1.FactoryMethod
{
    public class MySql : DatabaseMethod
    {
        public MySql(string connection)
            : base(connection)
        {
        }

        public MySql(string connection, string tableName)
            : base(connection, tableName)
        {
        }

        public override System.Data.DataTable GetScheme()
        {
            using (MySqlConnection connection = new MySqlConnection(@ConnectionString))
            {
                connection.Open();
                Table = connection.GetSchema("Tables");

            }

            return Table;
        }


        public override ConnectionAdapter getConnection(string str)
        {
            return new MySQLConnectionAdapterImpl(str);
        }

        public override CommandAdapter getCommandAdapter(string command, ConnectionAdapter connectionAdapter)
        {
            return new MySQLCommandAdapterImpl(command, connectionAdapter);
        }
    }
}