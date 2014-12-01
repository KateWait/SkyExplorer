using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SkyExplorer1.FactoryMethod
{
    public class MSSQLConnectionAdapterImpl: ConnectionAdapter
    {
        private SqlConnection mySqlConnection;

        public MSSQLConnectionAdapterImpl(String str)
        {
            mySqlConnection = new SqlConnection(@str);
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