using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class fund_description
    {
        [Key]
        public string fund_descriptionID { get; set; }
        public string Fund_sub_catID { get; set; }
        public virtual Fund_sub_cat fund_sub_cat { get; set; }
        public string Fund_CategoriesID { get; set; }
        public virtual Fund_Categories fund_Categories { get; set; }


    }
}