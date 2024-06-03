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
    public class ServiceBookingController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpPost]
        public IEnumerable<spInsertServiceBooking_Result> InsertServiceBooking(ServiceBooking sb)
        {
            try
            {
                return GE.spInsertServiceBooking(sb.Id, sb.ServiceId, sb.ServiceName, sb.UserId, sb.UserName, sb.Mobile, sb.Address,
               sb.LocationId, sb.Latitude, sb.Longitude, sb.PaymentType, sb.Amount, sb.ServiceDate, sb.ServiceTime, sb.ServiceType,
               sb.Remarks, sb.OfferCode, sb.Discount, sb.SupervisorId, sb.PaymentCode, sb.AdminRemarks, sb.SupervisorRemarks, sb.TechnicianRemarks).AsEnumerable();
            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return null;
            }
        }
        [HttpGet]
        public IEnumerable<spUpdateBillAmountWithServiceBookingId_Result> UpdateBillAmountWithServiceBookingId(float amnt, int sbid)
        {
            return GE.spUpdateBillAmountWithServiceBookingId(amnt, sbid).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAllBookingDetails_Result> GetAllBookingDetails()
        {

            return GE.spGetAllBookingDetails().AsEnumerable();
        }




        [HttpGet]

        public IEnumerable<spGetAllBookingDetailsWithSupervisorId_Result> GetAllSupervisorBookingDetails(int Supervisorid)
        {
            try

            {
                return GE.spGetAllBookingDetailsWithSupervisorId(Supervisorid).AsEnumerable();
            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return null;
            }
        }
        [HttpGet]
        public IEnumerable<spAdminUpdateServicebooking_Result> UpdateServicebooking(int Id, string AdminRemarks, string SuperRemarks, DateTime ServiceDate, DateTime ServiceTime)
        {
            return GE.spAdminUpdateServicebooking(Id, AdminRemarks, SuperRemarks, ServiceDate, ServiceTime).AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<UpdateServiceBookingStatus_Result> UpdateServiceBookingStatusandInvoicedate(int bookingid)
        {

            return GE.UpdateServiceBookingStatus(bookingid).AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<spGetAllBillDetailsWithBookingId_Result> GetAllBillDetailsWithBookingId(int bid)
        {
            return GE.spGetAllBillDetailsWithBookingId(bid).AsEnumerable();
        }

    }
 

}
