using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class ServiceBooking
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int LocationId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int PaymentType { get; set; }
        public float Amount { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime ServiceTime { get; set; }
        public int ServiceType { get; set; }
        public string Remarks { get; set; }
        public string OfferCode { get; set; }
        public float Discount { get; set; }
        public int SupervisorId { get; set; }
        public int Status { get; set; }
        public DateTime Systime { get; set; }
        public string PaymentCode { get; set; }
        public string AdminRemarks { get; set; }
        public string SupervisorRemarks { get; set; }
        public string TechnicianRemarks { get; set; }

    }
}