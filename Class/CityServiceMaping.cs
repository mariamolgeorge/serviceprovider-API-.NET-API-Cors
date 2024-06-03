using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public partial class CityServiceMaping
    {   
        public int Id { get; set; }
        public int CityId { get; set; }
        public int ServiceId { get; set; }
        public string Rules { get; set; }
        public string RateChart { get; set; }
        public string Description { get; set; }
        public int IsLive { get; set; }
        public int SupervisorId { get; set; }
        
    }
}