using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class BookingDetailsController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpGet]
        public IEnumerable<spGetAllTechniciansListWithServices_Result> GetAllExecutiveList()
        {
            try

            {

                return GE.spGetAllTechniciansListWithServices().AsEnumerable();
            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return null;

            }
        }

    }
}
