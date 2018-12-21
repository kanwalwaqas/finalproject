using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Account
    {
        [Key]
        public string AccountID { get; set; }
        public string DonorID { get; set; }
        public virtual Donor donor { get; set; }
        public string ReceiverID { get; set; }
        public virtual Receiver receiver { get; set; }
        public string AccountName { get; set; }
        public string duration { get; set; }
        public string AccountNumber { get; set; }
        public string status { get; set; }
        public string SortCode { get; set; }
        public string Remaning_Amount { get; set; }
        public string LoanID { get; set; }
        public virtual Loan loan { get; set; }
        public string TeamID { get; set; }
        public virtual Team team{ get; set; }


    }
}