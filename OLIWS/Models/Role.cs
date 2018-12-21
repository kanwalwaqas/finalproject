using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Role
    {
        [Key]
        public string RoleID { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
        public string Role_Name { get; set; }
        public string status { get; set; }
    }
}