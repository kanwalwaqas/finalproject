using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Areas.Admin.Models
{
    public class BalanceReport
    {
        [Display(Name = "Total Balance for Donation")]
        public String TotalAmount { get; set; }
        public String Education { get; set; }
        public String Health { get; set; }
        [Display(Name = "Others/Loan")]
        public String Others { get; set; }
        public String Team { get; set; }
        public String Admin { get; set; }
    }
}