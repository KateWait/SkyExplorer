using MySql.Data.MySqlClient;
using SkyExplorer1.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyExplorer1.FactoryMethod
{
    public class MySQLConnectionAdapterImpl : ConnectionAdapter
    {
        private MySqlConnection mySqlConnection;

        public MySQLConnectionAdapterImpl(String str)
        {
            mySqlConnection = new MySqlConnection(@str);
        }

        public void Open()
        {
            this.mySqlConnection.Open();
        }

        public void Dispose()
        {
            this.mySqlConnection.Dispose();
        }


        public object getAdaptee()
        {
            return mySqlConnection;
        }
    }
}