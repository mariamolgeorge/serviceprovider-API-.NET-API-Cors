using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public partial class UsersServiceProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public int SupervisorId { get; set; }
        public int IsLive { get; set; }
        public int Status { get; set; }
        public int IsBill { get; set; }
        public int IsBooking { get; set; }

        public string Password { get; set; }
        public List<ServiceProviderServiceMapping> ServiceProviderServiceMapping { get; set; }
        public List<ListOfId> ListOfId { get; set; }
    }
}