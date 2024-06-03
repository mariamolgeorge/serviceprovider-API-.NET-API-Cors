using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class PastCallController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();

        [HttpGet]
        public IEnumerable<spGetAllPastBookingDetails_Result> GetAllPastCallBookingDetails(int UserId)
        {

            return GE.spGetAllPastBookingDetails(UserId).AsEnumerable();
        }
    }

    }
