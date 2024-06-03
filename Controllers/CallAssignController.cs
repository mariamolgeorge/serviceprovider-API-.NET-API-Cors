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
    public class CallAssignController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();


        [HttpPost]
        public IEnumerable<spInsertCallAssign_Result> InsertCallAssign(CallAssign ca)
        {
            try
            {
                return GE.spInsertCallAssign(ca.Id, ca.CustomerId, ca.TechnicianId, ca.AssignedTime, ca.AssignedBy, ca.ServiceBookingId).AsEnumerable();
            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<spGetAllCallAssignWithTechnicianId_Result> GetAllCallAssignWithTechnicianId(int techid)
        {
            return GE.spGetAllCallAssignWithTechnicianId(techid).AsEnumerable();
        }


        //[HttpGet]
        //public IEnumerable<spGetStartCallAssign_Result> GetStartCallAssign(int callid, string location,string StartImageUrl)
        //{
        //    return GE.spGetStartCallAssign(callid, location).AsEnumerable();
        //}


        //public spGetStartCallAssign_Result GetStartCallAssign(int callid, string location, string StartImageUrl)
        //{
        //    try
        //    {
        //        spGetStartCallAssign_Result dt = GE.spGetStartCallAssign(callid, location, StartImageUrl).SingleOrDefault();
        //        if (dt.Id > 0 && dt.Error == 0)
        //        {
        //            if (!String.IsNullOrEmpty(StartImageUrl))
        //            {
        //                if (StartImageUrl.Length > 1)
        //                {

        //                    Utils.SaveImage("~/assets/images/StartImages/" + dt.Id.ToString() + ".jpg", StartImageUrl);
        //                }
        //            }
        //        }

        //        return dt;

        //    }
        //    catch (Exception ex)
        //    {
        //        string val = ex.Message;
        //        return null;
        //    }
        //}


        //[HttpGet]
        //public IEnumerable<spEndCallAssign_Result> EndCallAssign(int callassignid, string remarks, float amount, int status,string StopImageUrl)
        //{
        //    try
        //    {

        //        return GE.spEndCallAssign(callassignid, remarks, amount, status).AsEnumerable();
        //    }

        //    catch (Exception ex)
        //    {
        //        string val = ex.Message;
        //        return null;
        //    }
        //}

        //public spEndCallAssign_Result EndCallAssign(int callassignid, string remarks, float amount, int status, string StopImageUrl)
        //{
        //    try
        //    {
        //        spEndCallAssign_Result dtt = GE.spEndCallAssign(callassignid, remarks, amount, status, StopImageUrl).SingleOrDefault();
        //        if (dtt.Id > 0 && dtt.Error == 0)
        //        {
        //            if (!String.IsNullOrEmpty(StopImageUrl))
        //            {
        //                if (StopImageUrl.Length > 1)
        //                {

        //                    Utils.SaveImage("~/assets/images/StopImages/" + dtt.Id.ToString() + ".jpg", StopImageUrl);
        //                }
        //            }
        //        }

        //        return dtt;

        //    }
        //    catch (Exception ex)
        //    {
        //        string val = ex.Message;
        //        return null;
        //    }

       // }

        [HttpGet]
        public IEnumerable<spGetAllCallAssignDetailsWithServiceBookingId_Result> GetAllCallAssignDetailsWithServiceBookingId(int servicebookingid)
        {
            return GE.spGetAllCallAssignDetailsWithServiceBookingId(servicebookingid).AsEnumerable();
        }
       
    }
}

