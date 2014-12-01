using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyExplorer1.ConectionStrings
{
    public class ConnectionString
    {
        string connectionString;
        public string _ConnectionString
        {
            get 
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }
    }
}