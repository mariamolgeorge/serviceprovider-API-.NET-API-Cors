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
    public class StartServiceController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpPost]
        public spGetStartCallAssign_Result GetStartCallAssign(CallAssign ca)
        {
            try
            {
                spGetStartCallAssign_Result dt = GE.spGetStartCallAssign(ca.Id,ca.StartLocation,ca.StartImageUrl).SingleOrDefault();
                if (dt.Id > 0 && dt.Error == 0)
                {
                    if (!String.IsNullOrEmpty(ca.StartImageUrl))
                    {
                        if (ca.StartImageUrl.Length > 1)
                        {

                            Utils.SaveImage("~/assets/images/StartImages/" + dt.Id.ToString() + ".jpg", ca.StartImageUrl);
                        }
                    }
                }

                return dt;

            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return null;
            }
        }


    }
}
