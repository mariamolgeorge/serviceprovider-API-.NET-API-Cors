using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class UsersLoginController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();

        [HttpGet]
        public IEnumerable<spUserLoginCheck_Result>UserLoginCheck(string UserName,string Password)
        {
            return GE.spUserLoginCheck(UserName, Password).AsEnumerable();
        }
       
    }
}
