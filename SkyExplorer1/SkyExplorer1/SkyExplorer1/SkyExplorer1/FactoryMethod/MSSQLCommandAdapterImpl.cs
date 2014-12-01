using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SkyExplorer1.FactoryMethod
{
    public class MSSQLCommandAdapterImpl: CommandAdapter
    {
        private SqlCommand command;

        public MSSQLCommandAdapterImpl(string str, ConnectionAdapter connAdapter)
        {
            command = new SqlCommand(str, (SqlConnection)connAdapter.getAdaptee());
        }

        public IDataReader ExecuteReader()
        {
            return command.ExecuteReader();
        }

        public void Dispose()
        {
            command.Dispose();
        }
    }
}