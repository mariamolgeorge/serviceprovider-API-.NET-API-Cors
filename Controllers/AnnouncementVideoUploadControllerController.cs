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
    public class AnnouncementVideoUploadControllerController : ApiController
    {

        GmmepEntities GE = new GmmepEntities();

    
        [HttpPost]
        public string UploadJsonFile()
        {
            try
            {
                int iUploadedCnt = 0;
                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
                string sPath = "";
                sPath = HttpContext.Current.Server.MapPath("~/assets/images/AnnouncementVideos/");
                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                // CHECK THE FILE COUNT.
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    System.Web.HttpPostedFile hpf = hfc[iCnt];
                    if (hpf.ContentLength > 0)
                    {
                        spUpdateAnnouncementVideoUrl_Result rlt = GE.spUpdateAnnouncementVideoUrl(Int32.Parse(hpf.FileName.Split('.')[0])).SingleOrDefault();
                         if (rlt.Id > 0 && rlt.Error == 0)
                        {
                            hpf.SaveAs(sPath + hpf.FileName);
                        }
                        // spInsertRoomImageUpload_Result tm = RB.spInsertRoomImageUpload(Int32.Parse(hpf.FileName.Split('_')[0]), Path.GetExtension(hpf.FileName), Int32.Parse(hpf.FileName.Split('_')[1])).SingleOrDefault();
                        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)            
                        // SAVE THE FILES IN THE FOLDER.
                        //hpf.SaveAs(sPath + Path.GetFileName(Path.GetExtension(hpf.FileName)));

                        // hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));

                        iUploadedCnt = iUploadedCnt + 1;
                    }
                }
                // RETURN A MESSAGE (OPTIONAL).
                if (iUploadedCnt > 0)
                {
                    return iUploadedCnt + " Files Uploaded Successfully";
                }
                else
                {
                    return "Upload Failed";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
