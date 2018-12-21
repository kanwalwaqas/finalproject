using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class BalanceDetails
    {
        [Key]
        public String BalanceID { get; set; }
        public float TotalAmount { get; set; }
        public float Education { get; set; }
        public float Health { get; set; }
        public float Others { get; set; }
        public float Team { get; set; }
        public float Admin { get; set; }
        public String dateInformation { get; set; }
        public String UserID { get; set; }
        public String DonorID { get; set; }

    }
}