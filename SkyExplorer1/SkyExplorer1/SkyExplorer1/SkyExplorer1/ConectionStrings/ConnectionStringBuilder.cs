using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyExplorer1.ConectionStrings
{
    abstract public class ConnectionStringBuilder
    {
        protected ConnectionString connectionString;
        public ConnectionString ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        public void CreateConnectionString()
        {
            connectionString = new ConnectionString();
        }

        public abstract void BuildConnectionString();
    }
}