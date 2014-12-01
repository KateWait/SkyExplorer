using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyExplorer1.Builder
{
    abstract public class StringBuilder2
    {
        public Dictionary<string, string> Dictionary { get; set; }
        public string StringC { get; set; }


        public abstract void BuildPrefix();
        public abstract void BuildAuthentication();
        public abstract void BuildWholeString();
    }
}