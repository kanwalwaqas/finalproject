using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Role_managment
    {
        [Key]
        public int Role_managmentID { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
        public int RoleID { get; set; }
        public virtual Role role { get; set; }
    }
}