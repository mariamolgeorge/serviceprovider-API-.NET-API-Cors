using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public partial class Services
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public float AdditionalRate { get; set; }
        public int Status { get; set; }
        public string RateChart { get; set; }
        public float AdvanceAmount { get; set; }
        public List<ServiceRateChartMapping> ServiceRateChartMappingList { get; set; }

    }
}