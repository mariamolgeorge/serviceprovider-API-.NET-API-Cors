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
    public class TechnicianStatusController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();

        [HttpPost]
        public IEnumerable<spInsertTechnicianStatus_Result> InsertTechnicianStatus(TechnicianStatus ts)
        {
           try
            {
                return GE.spInsertTechnicianStatus(ts.Id,ts.Name,ts.Code,ts.Status).AsEnumerable();
          }
         catch (Exception ex)
            {
                string val = ex.Message;
                return null;
          }
        }


        [HttpGet]
        public IEnumerable<spGetAllTechnicianStatus_Result> GetAllTechnicianStatus()
        {

            return GE.spGetAllTechnicianStatus().AsEnumerable();
        }

    }


   


}
