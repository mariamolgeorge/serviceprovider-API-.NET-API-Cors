﻿using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class LiveCallController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpGet]
        public IEnumerable<spGetAllLiveBookingDetails_Result> GetAllLiveBookingDetails(int UserId)
        {

            return GE.spGetAllLiveBookingDetails(UserId).AsEnumerable();
        }


    }
}
