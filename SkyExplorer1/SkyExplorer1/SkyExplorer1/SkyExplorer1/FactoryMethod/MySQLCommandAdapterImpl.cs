using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SkyExplorer1.FactoryMethod
{
    public class MySQLCommandAdapterImpl : CommandAdapter
    {
        private MySqlCommand command;

        public MySQLCommandAdapterImpl(string str, ConnectionAdapter connAdapter)
        {
            command = new MySqlCommand(str, (MySqlConnection)connAdapter.getAdaptee());
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