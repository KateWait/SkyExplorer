using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyExplorer1.FactoryMethod
{
    interface ICreator
    {
        DataTable SchemeFactory(string coon);

        DataTable SelectFactory(string conn, string tableName);

        DataTable SelectTopFactory(string top, string conn, string tableName);
    }
}
