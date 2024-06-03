using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class DeleteController : ApiController
    {

        GmmepEntities GE = new GmmepEntities();

        [HttpGet]
        public IEnumerable<spDeleteTechnicians_Result> DeleteService(int id)
        {
            return GE.spDeleteTechnicians(id).AsEnumerable();

        }
        [HttpGet]
        public IEnumerable<spDeleteData_Result> DeleteData(string Tablename, int Id)
        {
            return GE.spDeleteData(Tablename, Id).AsEnumerable();
        }

    }
}
