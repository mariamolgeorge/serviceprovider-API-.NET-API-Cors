using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class AvailablePincode
    {
        public int Id { get; set; }

        public int LocationId { get; set; }
        public string AreaName { get; set; }
        public string FromPincode { get; set; }
        public string ToPincode { get; set; }
        public string Code { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
    }
}