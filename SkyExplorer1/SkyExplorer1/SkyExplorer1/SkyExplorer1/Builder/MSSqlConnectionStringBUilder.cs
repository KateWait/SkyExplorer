using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SkyExplorer1.Builder
{
    public class MSSqlConnectionStringBUilder : StringBuilder2
    {
        List<string> PropertyList1 = new List<string>() { "Server", "Database", "Trusted_Connection" };
        List<string> PropertyList2 = new List<string>() { "User Id", "Password" };
        StringBuilder sb;

        public MSSqlConnectionStringBUilder(Dictionary<string, string> dict)
        {
            Dictionary = dict;
            sb = new StringBuilder();
        }

        public override void BuildPrefix()
        {
            foreach (var a in PropertyList1)
            {
                if (Dictionary.ContainsKey(a))
                {
                    sb.Append(a);
                    sb.Append("=");
                    sb.Append(Dictionary[a]);
                    sb.Append(";");
                }
            }
        }

        public override void BuildAuthentication()
        {
            foreach (var a in PropertyList2)
            {
                if (Dictionary.ContainsKey(a) && Dictionary[a] != "")
                {
                    sb.Append(a);
                    sb.Append("=");
                    sb.Append(Dictionary[a]);
                    sb.Append(";");
                }
            }
        }

        public override void BuildWholeString()
        {
            StringC = sb.ToString();
        }
    }
}