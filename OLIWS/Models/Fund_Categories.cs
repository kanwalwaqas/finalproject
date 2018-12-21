using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Fund_Categories
    {
        [Key]
        public string Fund_CategoriesID { get; set; }
        public string fund_cat { get; set; }
        public string Education { get; set; }
        public string Health { get; set; }
        public string Loan { get; set; }
        public string status { get; set; }
        public string frequency { get; set; }
        public string cat_img { get; set; }
        public string cat_title { get; set; }
        public string cat_decsription{ get; set; }


    }
}