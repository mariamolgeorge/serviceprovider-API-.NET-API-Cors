using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class CallAssign
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TechnicianId { get; set; }
        public int ServiceBookingId { get; set; }
        public DateTime AssignedTime { get; set; }
        public int AssignedBy { get; set; }
        public string StartImageUrl { get; set; }
        public string StopImageUrl { get; set; }
        public string StartLocation { get; set; }
        public string TechnicianRemarks { get; set; }
        public float Amount { get; set; }
        public int CallStatus { get; set; }
    }
}