using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace SkyExplorer1.FactoryMethod
{
    abstract public class DatabaseMethod
    {
        private DataTable table;
        private string connectionString;
        private string tableName;

        public DataTable Table
        {
            get
            {
                return table;
            }
            set
            {
                table = value;
            }
        }
        public string ConnectionString
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

        public string TableName 
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }

        public DatabaseMethod(string conString)
        {
            ConnectionString = conString;
        }

        public DatabaseMethod(string conString, string tableName)
        {
            ConnectionString = conString;
            TableName = tableName;
        }

        public abstract DataTable GetScheme();

        
        public DataTable GetSelect(string query = "")
        {
            Table = new DataTable();
            using (ConnectionAdapter connection = getConnection(@ConnectionString))
            {
                // Connect to the database then retrieve the schema information.
                connection.Open();

                string command = "";
                if (query != "")
                {
                    command = query;
                }
                else
                {
                    command = "SELECT * FROM " + TableName;
                }
                using (CommandAdapter cmd = getCommandAdapter(command, connection))
                {
                    using (IDataReader reader = cmd.ExecuteReader())
                    {

                        Table.Load(reader);
                        return Table;
                    }
                }
            }
        }

        public abstract ConnectionAdapter getConnection(String str);

        public abstract CommandAdapter getCommandAdapter(string command, ConnectionAdapter commandAdapter);

    }

    public interface ConnectionAdapter : IDisposable
    {
        void Open();
        Object getAdaptee();
    }

    public interface CommandAdapter : IDisposable
    {
        IDataReader ExecuteReader();
    }
}