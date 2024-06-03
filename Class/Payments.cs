using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class Payments
    {
        public int Id { get; set; }
        public int ServiceBookingId { get; set; }
        public float Amount { get; set; }
        public int Status { get; set; }
        public DateTime Systime { get; set; }
    }
}