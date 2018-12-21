using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Country
    {
        [Key]
        public string CountryID { get; set; }
        public string country_name { get; set; }
        public bool status { get; set; }

    }
}