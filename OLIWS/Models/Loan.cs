using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Loan
    {
        [Key]
        public string LoanID { get; set; }
        public string Loan_Type { get; set; }
        public string loan_amount { get; set; }
        public string source_finance { get; set; }
        public string loan_Limit { get; set; }
        public string return_amount { get; set; }
        public string remaining_balance { get; set; }
        public string return_date { get; set; }
       




    }
}