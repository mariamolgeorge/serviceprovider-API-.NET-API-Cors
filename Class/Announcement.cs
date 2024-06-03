using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public class Announcement
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int VideoType { get; set; }
        public int Status { get; set; }
        public DateTime Systime { get; set; }
        public int OrderNo { get; set; }
        public int ThemeType { get; set; }
        public int AnnouncementGroupId { get; set; }
        public int LinkType { get; set; }
        public string Link { get; set; }
    }
}