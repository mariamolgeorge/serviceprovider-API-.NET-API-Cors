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
    public class PagesController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpPost]
        public IEnumerable<spInsertPages_Result> InsertPages(Pages pages)
        {
            return GE.spInsertPages(pages.Id,pages.Name,pages.ComponentName).AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<spGetAllPages_Result> GetAllPages()
        {
            return GE.spGetAllPages().AsEnumerable();
        }
    }
}
