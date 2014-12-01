using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyExplorer1.Controllers
{
    public class DetailsController : Controller
    {
        //
        // GET: /Details/

        public ActionResult Index(string tableName)
        {
           // const string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Katarzyna\Documents\University.mdf;Integrated Security=True;Connect Timeout=30";

            const string connectionString = @"Server=NB-KCZEKAJ\SQLEXPRESS;Database=SampleDB;Trusted_Connection=True";

            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Connect to the database then retrieve the schema information.
                connection.Open();
                string command = "SELECT * FROM " + tableName;
                using (SqlCommand cmd = new SqlCommand(command, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int columnNumber = reader.FieldCount;
                            for (int i = 0; i < columnNumber; i++)
                            {
                                var a = reader.GetValue(i);
                            }
                        }
                    }
                }
            }


            return PartialView("Details");
        }

    }
}