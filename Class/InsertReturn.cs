using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InIT.API.GMMEP.Class
{
    public partial class InsertReturn
    {
        public int Id { get; set; }
        public int Error { get; set; }
        public InsertReturn(int id, int error)
        {
            Id = id;
            Error = error;
        }
        public InsertReturn()
        {
            Id = 0;
            Error = 0;
        }

    }
}