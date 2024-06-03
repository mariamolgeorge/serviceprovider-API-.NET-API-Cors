using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class AuthoriseController : ApiController
    {


        GmmepEntities GE = new GmmepEntities();
        [HttpGet]
        public IEnumerable<spUpdateServiceBookingAuthoriseStatus_Result> UpdateServiceBookingAuthoriseStatus(int bookingid)
        {

            return GE.spUpdateServiceBookingAuthoriseStatus(bookingid).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAllClosedReports_Result> GetAllClosedReports(DateTime fromdate, DateTime todate)
        {

            return GE.spGetAllClosedReports(fromdate, todate).AsEnumerable();
        }
    }
}
