using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SkyExplorer1.FactoryMethod;

namespace SkyExplorer1.FactoryMethod
{
    public class MSSql : DatabaseMethod
    {
        public MSSql(string connection)
            : base(connection)
        {
        }

        public MSSql(string connection, string tableName)
            : base(connection, tableName)
        {
        }

        public override System.Data.DataTable GetScheme()
        {
            using (var connection = new SqlConnection(@ConnectionString))
            {
                connection.Open();
                Table = connection.GetSchema("Tables");

            }

            return Table;
        }

        public override ConnectionAdapter getConnection(string str)
        {
            return new MSSQLConnectionAdapterImpl(str);
        }

        public override CommandAdapter getCommandAdapter(string command, ConnectionAdapter commandAdapter)
        {
            return new MSSQLCommandAdapterImpl(command, commandAdapter);
        }
    }
}