using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class State
    {
        [Key]

        public string StateID { get; set; }
        public string state_name { get; set; }
        public bool status { get; set; }
        public string CountryID { get; set; }
        public virtual Country country { get; set; }
    }
}