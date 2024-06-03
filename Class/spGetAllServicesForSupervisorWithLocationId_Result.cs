using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class spGetAllServicesForSupervisorWithLocationId_Result
    {
      public int ServiceId { get; set; }
       public int CityId { get; set; }
       public string LocationName { get; set; }
        public string Name { get; set; }
          public int  Id { get; set; }
        public int CityServiceMappingId { get; set; }
    }
}