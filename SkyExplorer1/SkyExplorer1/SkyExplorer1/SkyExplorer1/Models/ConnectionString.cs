using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyExplorer1.Models
{
    public class ConnectionString
    {
        public int ConnectionStringID { get; set; }
        public string Connection { get; set; }
        //ref
        public DatabaseType DatabaseType { get; set; }
    }
}