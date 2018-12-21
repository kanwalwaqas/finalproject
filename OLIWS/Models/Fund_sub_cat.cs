using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Fund_sub_cat
    {
        [Key]
        public string Fund_sub_catID { get; set; }
        public string AdmissionFee { get; set; }
        public string Accessories { get; set; }
        public string Uniform { get; set; }
        public string fee_cat { get; set; }
        public string semesterFee { get; set; }
        public string Annual { get; set; }
        public string stationary_cat { get; set; }
        public string bags { get; set; }
        public string books_notes { get; set; }
        public string uniform_cat { get; set; }
        public string  Dress { get; set; }
        public string shoes { get; set; }
        public string Medicine { get; set; }
        public string Minor_Surgury { get; set; }
        public string Test_Reports { get; set; }
        public string medi_cat { get; set; }
        public string status { get; set; }


    }
}