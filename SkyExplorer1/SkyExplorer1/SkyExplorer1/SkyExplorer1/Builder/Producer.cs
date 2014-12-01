using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyExplorer1.Builder
{
    public class Producer
    {
        public StringBuilder2 StringB;

        public void SetBuilder(StringBuilder2 b)
        {
            StringB = b;
        }


        public void CreateConnectionString()
        {
            StringB.BuildPrefix();
            StringB.BuildAuthentication();
            StringB.BuildWholeString();
        }
    }
}