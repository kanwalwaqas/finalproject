using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Profile_biulding
    {
        [Key]
        public string Profile_biuldingID { get; set; }
        public string picture { get; set; }
        public string personal_info { get; set; }
        public string Qualification { get; set; }
        public string Shift_Of_Working { get; set; }
        public string Area_of_Work { get; set; }
        public string Discription { get; set; }
        public string Id { get; set; }      
        public virtual ApplicationUser applicationUser { get; set; }
    }
}