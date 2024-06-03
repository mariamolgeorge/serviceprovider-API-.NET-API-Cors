using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class SupervisorLocationServiceMapping
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int ServiceId { get; set; }
        public int SupervisorId { get; set; }
        public int CityServiceMappingId { get; set; }
    }
}