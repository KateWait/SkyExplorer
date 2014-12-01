using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyExplorer1.ConectionStrings
{
    public class Producer
    {
        private ConnectionStringBuilder connectionBuilder;
        public ConnectionStringBuilder ConnectionBuilder
        {
            get
            {
                return connectionBuilder;
            }
            set
            {
                connectionBuilder = value;
            }
        }

        public ConnectionString CString
        {
            get
            {
                return connectionBuilder.ConnectionString;
            }
        }

        public void ConstructConnectionString()
        {
            connectionBuilder.BuildConnectionString();
        }
    }
}