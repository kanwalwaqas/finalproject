using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Funds
    {
        [Key]
        public int FundID { get; set; }
        public string Fund_Type { get; set; }
        public string Fund_Limit { get; set; }
    }
}