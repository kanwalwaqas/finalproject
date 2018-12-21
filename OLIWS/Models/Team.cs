using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Team
    {
        [Key]
        public string TeamID { get; set; }
        public string verify  { get; set; }
        public string Duration { get; set; }
        public string Timing { get; set; }
        public string experience { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
        public string team_img { get; set; }
       public string team_title { get; set; }
        public string team_description { get; set; }


    }
}