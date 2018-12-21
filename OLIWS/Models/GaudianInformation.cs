using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class GaudianInformation
    {
        [Key]
        public String GaudianKey { get; set; }
        public String Gardian_Name { get; set; }
        public String Gardian_Members { get; set; }
        public String Gardian_Income { get; set; }
        public String Gardian_Occupation { get; set; }
        public String Gardian_Oranization { get; set; }
        public String Loan_Amount { get; set; }
        public String UserID { get; set; }
        public String RecieverID { get; set; }
        

    }
}