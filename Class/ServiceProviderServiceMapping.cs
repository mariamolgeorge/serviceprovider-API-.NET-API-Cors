using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public partial class ServiceProviderServiceMapping
    {
        public int Id { get; set; }
        public int UsersServiceProviderId { get; set; }
        public int ServiceId { get; set; }
    }
}