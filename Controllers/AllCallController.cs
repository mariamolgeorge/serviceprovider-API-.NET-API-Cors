using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class AllCallController : ApiController
    {

        GmmepEntities GE = new GmmepEntities();


        [HttpGet]
        public IEnumerable<spGetAllCallReports_Result> GetAllCallReports(DateTime fromdate,DateTime todate)
        {
            try {

            return GE.spGetAllCallReports(fromdate,todate).AsEnumerable();
                    }
        catch (Exception ex)
            {
                string val = ex.Message;
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<spRevokeServiceBookingStatus_Result> UpdateServiceBookingStatus(int bookingid)
        {

            return GE.spRevokeServiceBookingStatus(bookingid).AsEnumerable();
        }
    }
}
