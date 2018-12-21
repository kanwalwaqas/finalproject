using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Areas.Admin.Models
{
    public class ApprovalItems
    {

        public String Status { get; set; }
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
        public String RequiredAmount { get; set; }

        public String frequency { get; set; }

        public String AdmissionFee { get; set; }
        public String Uniform { get; set; }
        public String Accessories { get; set; }
        public String fee_cat { get; set; }
        public String semesterFee { get; set; }
        public String Annual { get; set; }
        public String Minor_Surgury { get; set; }
        public String Medicine { get; set; }
        public String Test_Reports { get; set; }

        public String GaudianKey { get; set; }
        public String Gardian_Name { get; set; }
        public String Gardian_Members { get; set; }
        public String Gardian_Income { get; set; }
        public String Gardian_Occupation { get; set; }
        public String Gardian_Oranization { get; set; }





    }
}