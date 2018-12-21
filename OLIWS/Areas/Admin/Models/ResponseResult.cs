using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLIWS.Areas.Admin.Models
{
    public class ResponseResult
    {
        public String status { get; set; }
        public String message { get; set; }
        public String result { get; set; }
    }
}