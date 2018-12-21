using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Donor
    {
        [Key]
        public string DonorID { get; set; }
        public string frequency { get; set; }
        public string Amount { get; set; }
        public string status { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
        public string Fund_TypeID { get; set; }
        public virtual Fund_Type fund_Type { get; set; }
        public string fund_descriptionID { get; set; }
        public virtual fund_description fund_des { get; set; }







    }
}
