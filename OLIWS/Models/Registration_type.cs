using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Registration_type
    {
        public string Registration_typeID { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
        public string RoleID { get; set; }
        public virtual Role role { get; set; }
        public string status { get; set; }

    }
}