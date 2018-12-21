using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Accounts
    {
        [Key]
        public int AccountID { get; set; }
        public int AdminID { get; set; }
        public virtual Admin admin { get; set; }
        public int DonorID { get; set; }
        public virtual Donor donor { get; set; }
        public int ClientID { get; set; }
        public virtual Client client { get; set; }
        public int RegisterID { get; set; }
        public virtual Register register { get; set; }
        public int FundID { get; set; }
        public virtual Funds fund { get; set; }
        public int LoanID { get; set; }
        public virtual Loan loan { get; set; } 

    }
}