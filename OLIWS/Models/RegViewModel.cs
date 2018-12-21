using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OLIWS.Models
{
   
    public class RegViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "User Status")]
        public bool userStatus { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string in_org { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Date_of_birth { get; set; }
        public string CNIC { get; set; }
       
        public string Selected_city { get; set; }
        public string qualification { get; set; }
        public string Selected_Area { get; set; }
        public string Address { get; set; }
        public string Muslim { get; set; }
        public string Category { get; set; }

        public string owner_Name { get; set; }
        public string owner_LastName { get; set; }
        public string owner_CNIC { get; set; }
        public string owner_Address { get; set; }
        public string owner_PhoneNum { get; set; }
        public string owner_Email { get; set; }
     
        public string Zakat { get; set; }
        public string Sadaqah { get; set; }
        public string Usher { get; set; }
        public string zakat_ul_fitr { get; set; }
        public string khums { get; set; }
        public string Atia_o_Khairat { get; set; }
        public string frequency { get; set; }
        public string Education { get; set; }
        public string Health { get; set; }
        public string Other { get; set; }
        public string Amount { get; set; }
        public string AccountName { get; set; }
        public string duration { get; set; }
        public string AccountNumber { get; set; }

        public string SortCode { get; set; }
        public string AdmissionFee { get; set; }
        public string Accessories { get; set; }
        public string Uniform { get; set; }
        public string fee_cat { get; set; }
        public string semesterFee { get; set; }
        public string Annual { get; set; }
        public string bags { get; set; }
        public string books_notes { get; set; }
        public string Dress { get; set; }
        public string Medicine { get; set; }
        public string Minor_Surgury { get; set; }
        public string Test_Reports { get; set; }
        public string medi_cat { get; set; }
        public string fund_cat { get; set; }
     
        public string Loan { get; set; }
        public string Loan_Type { get; set; }
        public string loan_amount { get; set; }
        public string source_finance { get; set; }
        public string HealthAmount { get; set; }
    }
}