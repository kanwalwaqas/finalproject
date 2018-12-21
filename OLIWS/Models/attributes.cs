using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class attributes
    {
        [Key]
        public int attributesID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string CNIC { get; set; }
        public string Gender { get; set; }
        public string Date_of_birth { get; set; }
        public string Selected_city { get; set; }
        public string Selected_Area { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }




    }
}