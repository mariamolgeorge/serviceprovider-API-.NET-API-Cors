using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class AnnouncementGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int OrderNo { get; set; }
        public int Status { get; set; }
        public DateTime Systime { get; set; }
        public int ThemeType { get; set; }
        public List<Announcement> AnnouncementList { get; set; }
    }
}