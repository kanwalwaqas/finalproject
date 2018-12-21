using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Receiver
    {
        [Key]
        public string ReceiverID { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public string fund_limit { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
        public string fund_descriptionID { get; set; }
        public virtual fund_description fund_description { get; set; }
        public string LoanID { get; set; }
        public virtual Loan loan { get; set; }



    }
}