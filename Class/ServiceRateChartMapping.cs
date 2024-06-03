using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class ServiceRateChartMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
        public float Amount { get; set; }
        public  DateTime UptoHours { get; set; }
    }
}