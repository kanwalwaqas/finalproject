using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class profile_building
    {
        [Key]
        public int profile_buildingID { get; set; }
        public string picture { get; set; }
        public string personal_info { get; set; }
        public int Role_managmentID { get; set; }
        public virtual Role_managment role_managment { get; set; }


    }
}