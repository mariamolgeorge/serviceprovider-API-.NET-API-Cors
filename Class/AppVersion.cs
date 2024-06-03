using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class AppVersion
    {


        public int IsForceUpdate { get; set; }
        public string Version { get; set; }
        public string AppUrl { get; set; }
        public AppVersion(int isforceupdate, string version)
        {
            IsForceUpdate = isforceupdate;
            Version = version;
        }

        public AppVersion(string url)
        {
            // AppUrl = "http://13.71.5.221/gmmep";

        }
    }
}