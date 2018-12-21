using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Areas.Admin.Models
{
    public class RecieverReports
    {

        public String ReceiverID { get; set; }
        public String Name { get; set; }
        public String Contact { get; set; }
        public String Email { get; set; }
        [Display(Name = "For Education")]
        public String RequiredForEducation { get; set; }
        [Display(Name = "For Health")]
        public String RequiredForHealth { get; set; }
        [Display(Name = "For Others")]
        public String RequiredForothers { get; set; }
        [Display(Name = "Required Amount")]
        public String  RequiredAmount { get; set; }
        public String Status { get; set; }

    }
}