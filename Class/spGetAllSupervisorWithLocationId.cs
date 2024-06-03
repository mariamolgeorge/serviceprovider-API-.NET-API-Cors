using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class spGetAllSupervisorWithLocationId_Result
    {
        public int SupervisorId { get; set; }
public int LocationId { get; set; }
public int ServiceId {get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
         
    }
}