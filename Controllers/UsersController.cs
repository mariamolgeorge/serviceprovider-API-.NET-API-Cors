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
    public class UsersController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();

        [HttpPost]
        public IEnumerable<spInsertUsers_Result> InsertUsers(Users users)
        {
            return GE.spInsertUsers(users.Id,users.Name,users.Mobile,users.Email,users.Address,users.PhoneNumber,users.CityId).AsEnumerable();
        }
    }
}
