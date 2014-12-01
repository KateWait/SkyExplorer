using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DatabaseExplorer.ViewModels
{
    public class HomeViewModel
    {
        public DataTable Table { get; private set; }
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public HomeViewModel(DataTable table, string conn)
        {
            Table = table;
            ConnectionString = conn;
        }

        public HomeViewModel(DataTable table, string conn, string name)
        {
            Table = table;
            ConnectionString = conn;
            TableName = name;
        }
    }
}