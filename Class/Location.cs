using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class Location
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public List<AvailablePincode> AvailablePincodeList { get; set; }
    }
}