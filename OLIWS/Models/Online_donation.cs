using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Online_donation
    {
        [Key]
        public int Online_donationID { get; set; }
        public string DonorNo { get; set; }
        public string AccountType { get; set; }

    }
}