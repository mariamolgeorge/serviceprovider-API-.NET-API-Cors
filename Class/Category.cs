using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}