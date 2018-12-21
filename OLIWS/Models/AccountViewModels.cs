using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OLIWS.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }


        [Display(Name = "Gender")]
        public string Gender { get; set; }


        [Display(Name = "Date of Birth")]
        public string Date_of_birth { get; set; }

        [Display(Name = "CNIC")]
        public string CNIC { get; set; }


        
        [Display(Name = "Selected City")]
        public string Selected_city { get; set; }

        
        [Display(Name = "Selected Area")]
        public string Selected_Area { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
       
        [Display(Name = "Category")]
        public string Category { get; set; }
      
        [Display(Name = "Muslim")]
        public string Muslim { get; set; }
        [Display(Name = "User Status")]
        public bool userStatus { get; set; }

        //[Required]
        //[Display(Name = "Date")]
        //public string Date { get; set; }
        [Display(Name = "image")]
        public string image { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Zakat { get; set; }
        public string Sadaqah { get; set; }
        public string Usher { get; set; }
        public string currentDate { get; set; }

        public string in_org { get; set; }
        public string zakat_ul_fitr { get; set; }
        public string khums { get; set; }
        public string Atia_o_Khairat { get; set; }
        public string fund_cat { get; set; }
        public string fund_type { get; set; }
        public string frequency { get; set; }
        public string frequency_educ { get; set; }
        public string AdmissionFee { get; set; }
        public string Accessories { get; set; }
        public string Uniform { get; set; }
        public string stationary_cat { get; set; }
        public string fee_cat { get; set; }
        public string uniform_cat { get; set; }
        public string educationAmount { get; set; }
        public string frequency_health { get; set; }
        public string Medicine { get; set; }
        public string qualification { get; set; }
        public string Minor_Surgury { get; set; }
        public string Test_Reports { get; set; }
        public string HealthAmount { get; set; }
        public string Education { get; set; }
        public string Health { get; set; }
        public string Other { get; set; }
        public string Amount { get; set; }
        public string AccountName { get; set; }
        public string duration { get; set; }
        public string AccountNumber { get; set; }
        // Loan Source Incom 
        public string reciever_fund_type { get; set; }
        public string Loan_For { get; set; }
        public string Gardian_Name { get; set; }
        public string Gardian_Members { get; set; }
        public string Gardian_Income { get; set; }
        public string Gardian_Occupation { get; set; }
        public string Gardian_Oranization { get; set; }
        public string Loan_Amount { get; set; }

        public string SortCode { get; set; }
    }

    public class ResetPasswordViewModel
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

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
