using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class volunteer
    {
        [Key]
        public string volunteerID { get; set; }
        public string qualification { get; set; }
        public string Duration_of_Work { get; set; }
        public string Area_of_Work { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser Users { get; set; }
        public string vol_img { get; set; }
        public string vol_title { get; set; }
        public string vol_description { get; set; }
    }
}