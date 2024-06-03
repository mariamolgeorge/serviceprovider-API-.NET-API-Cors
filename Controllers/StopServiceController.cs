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
    public class StopServiceController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpPost]
        public spEndCallAssign_Result EndCallAssign(CallAssign ca)
        {
            try
            {
                spEndCallAssign_Result dtt = GE.spEndCallAssign(ca.Id,ca.TechnicianRemarks,ca.Amount,ca.CallStatus,ca.StopImageUrl).SingleOrDefault();
                if (dtt.Id > 0 && dtt.Error == 0)
                {
                    if (!String.IsNullOrEmpty(ca.StopImageUrl))
                    {
                        if (ca.StopImageUrl.Length > 1)
                        {

                            Utils.SaveImage("~/assets/images/StopImages/" + dtt.Id.ToString() + ".jpg", ca.StopImageUrl);
                        }
                    }
                }

                return dtt;

            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return null;
            }

        }

        [HttpGet]
        public IEnumerable<spUpdateServicebookingServiceStatusByAdmin_Result> UpdateServicebookingStatusByAdmin(int id,int status)
        {
            return GE.spUpdateServicebookingServiceStatusByAdmin(id,status).AsEnumerable();
        }
    }
}
