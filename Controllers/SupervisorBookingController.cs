using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class SupervisorBookingController : ApiController
    {

        GmmepEntities GE = new GmmepEntities();

        [HttpGet]

        public IEnumerable<spGetAllBookingDetailsWithSupervisorId_Result> GetAllSupervisorBookingDetails(int Supervisorid)
        {
            try

            {
                return GE.spGetAllBookingDetailsWithSupervisorId(Supervisorid).AsEnumerable();
            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return null;
            }
        }

    }
}
