using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InIT.API.GMMEP.Class;

namespace InIT.API.GMMEP.Controllers
{
    public class AnnouncementController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
     
        [HttpPost]
        public InsertReturn InsertAnnouncements(AnnouncementGroup anncgrp)
        {
            try
            {
                spInsertAnnouncementGroup_Result rsltt = GE.spInsertAnnouncementGroup(anncgrp.Id, anncgrp.Name, anncgrp.Type, anncgrp.Status, anncgrp.OrderNo, anncgrp.ThemeType).SingleOrDefault();
                if (rsltt.Id > 0 && rsltt.Error == 0)
                {
                    for (int i = 0; i < anncgrp.AnnouncementList.Count; i++)
                    {
                        spInsertAnnouncements_Result rslt = GE.spInsertAnnouncements(anncgrp.AnnouncementList[i].Id, anncgrp.AnnouncementList[i].Name, anncgrp.AnnouncementList[i].Type, anncgrp.AnnouncementList[i].Heading,
                            anncgrp.AnnouncementList[i].Description, anncgrp.AnnouncementList[i].Date, anncgrp.AnnouncementList[i].ImageUrl, anncgrp.AnnouncementList[i].VideoUrl, anncgrp.AnnouncementList[i].VideoType,
                           0, anncgrp.AnnouncementList[i].OrderNo, rsltt.Id, anncgrp.AnnouncementList[i].ThemeType, anncgrp.AnnouncementList[i].LinkType, anncgrp.AnnouncementList[i].Link).SingleOrDefault();
                        if (rslt.Id > 0 && rslt.Error == 0)
                        {
                            if (anncgrp.AnnouncementList[i].Type == 1 || anncgrp.AnnouncementList[i].Type == 3 || anncgrp.AnnouncementList[i].Type == 4)
                            {
                                if (anncgrp.AnnouncementList[i].ImageUrl != null && anncgrp.AnnouncementList[i].ImageUrl.Length > 0)
                                {
                                    Utils.SaveImage("~/assets/images/AnnouncementImages/" + rslt.Id.ToString() + ".jpg", anncgrp.AnnouncementList[i].ImageUrl);
                                }
                            }
                        }
                    }
                }


                return new InsertReturn(Convert.ToInt32(rsltt.Id), Convert.ToInt32(rsltt.Error));
            }

            catch (Exception ex)
            {
                string val = ex.Message;
                string innex = ex.InnerException.Message;
                return null;
            }

        }


        [HttpGet]
        public IEnumerable<spDeleteData_Result> DeleteData(string tablename, int id)
        {
            return GE.spDeleteData(tablename, id).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAllAnnouncementsWithType_Result> GetAllAnnouncementsWithType(int type)
        {
            return GE.spGetAllAnnouncementsWithType(type).AsEnumerable();
        }


        //public Boolean CheckFileInServer(string FilePath)
        //{
        //    try
        //    {
        //        string spath = "";
        //        string filename = "";

        //        string base64Encoded = FilePath; //Value is 'base64 encoded string'
        //        string base64Decoded;
        //        byte[] data = System.Convert.FromBase64String(base64Encoded);
        //        base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);

        //        string[] urlstring = base64Decoded.Split('?');

        //        var str = urlstring[0];

        //        string[] urlstr = str.Split(new string[] { "assets" }, StringSplitOptions.None);
        //        spath = HttpContext.Current.Server.MapPath("~" + "/assets" + urlstr[1]);

        //        FileInfo file = new FileInfo(spath);
        //        if (file.Exists)
        //        {

        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //}


        public IEnumerable<spGetAllAnnouncementWithGroupId_Result> GetAllAnnouncementWithGroupId(int groupid)
        {
            return GE.spGetAllAnnouncementWithGroupId(groupid).AsEnumerable();
        }


        public IEnumerable<spGetAllAnnouncements_Result> GetAllAnnouncementsUserSide()
        {
            return GE.spGetAllAnnouncements().AsEnumerable();
        }

    }
}
