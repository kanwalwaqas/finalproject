using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class City
    {
        [Key]

        public string CityID { get; set; }
        public string city_name { get; set; }
        public bool status { get; set; }
        public string StateID { get; set; }
        public virtual State state { get; set; }
    }
}