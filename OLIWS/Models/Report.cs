using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Report
    {
        [Key]
        public string ReportID { get; set; }
        public string Registration_typeID { get; set; }
        public virtual Registration_type registration_type { get; set; }



    }
}