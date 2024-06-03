using InIT.API.GMMEP.Class;
using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class TimeSlotController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpPost]
        public IEnumerable<spInsertServiceTimeSlots_Result> InsertServiceTimeSlots(ServiceTimeSlot slot)
        {
            
        //DateTime dt = DateTime.Parse("6/22/2009 07:00:00 AM");
        //dt.ToString("hh:mm tt");

            return GE.spInsertServiceTimeSlots(slot.Id, slot.StartTime, slot.EndTime, slot.LocationId, slot.ServiceId, slot.Status).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAllServiceTimeSlotsWithServiceId_Result> GetAllServiceTimeSlotsWithServiceId(int serviceid)
        {
            return GE.spGetAllServiceTimeSlotsWithServiceId(serviceid).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAllServiceTimeSlots_Result> GetAllServiceTimeSlots()
        {
            return GE.spGetAllServiceTimeSlots().AsEnumerable();
        }
    }
}
