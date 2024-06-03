using InIT.API.GMMEP.Class;
using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class AppVersionController : ApiController
    {


        GmmepEntities GE = new GmmepEntities();
        //[HttpGet]
        //public AppVersion GetAppCurrentVersion()
        //{
        //    AppVersion av = new AppVersion(1, "0.0.3");
        //    return av;
        //}
        [HttpGet]
        public AppVersion GetAppCurrentVersion(int Type)
        {

            switch (Type)
            {
                case 1: //admin
                        // AppVersion av = new AppVersion(1, "0.1.1");
                    return new AppVersion(1, "0.1.8");

                case 2: //user
                    return new AppVersion(1, "0.2.1");

                case 3: //executive
                    return new AppVersion(1, "0.1.4");

            }


            //AppVersion av = new AppVersion(1, "0.1.1");
            //return av;
            return null;
        }
    }
}
