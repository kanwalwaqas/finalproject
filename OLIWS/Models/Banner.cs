using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OLIWS.Models
{
    public class Banner
    {
        [Key]
        public string Banner_Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public bool De_Activate { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser user { get; set; }
        public DateTime CurrentDate { get; set; }
        public string Description { get; set; }
        public Banner()
        {
            CurrentDate = DateTime.Now;
        }

    }
}