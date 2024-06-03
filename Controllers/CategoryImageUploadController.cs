using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class CategoryImageUploadController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpPost]
        public string UploadJsonFile()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();

                var httpRequest = System.Web.HttpContext.Current.Request;
                string uploadstatus = "";
                int iUploadedCnt = 0;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        var filePath = HttpContext.Current.Server.MapPath("~/assets/images/CategoryImages/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                        iUploadedCnt = iUploadedCnt + 1;

                    }


                }
                if (iUploadedCnt > 0)
                {
                    return iUploadedCnt + " Files Uploaded Successfully";
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }


    }
}
