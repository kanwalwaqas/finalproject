using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class ProfileViewModel
    {
        public List<Banner> banner { get; set; }
        public List<Account> P_account { get; set; }
        public List<Donor> P_donor { get; set; }
        public List<Fund_Categories> P_fund_Categories { get; set; }
        public List<Fund_Type> P_fund_Type { get; set; }
        public List<ApplicationUser> P_User { get; set; }

        public List<Fund_sub_cat> P_fund_sub_cat { get; set; }
        public List<Loan> P_loan { get; set; }
        public List<Registration_type> P_registration_type { get; set; }
        public List<Receiver> P_receiver { get; set; }
        public List<Role> P_role { get; set; }
        public List<Team> P_team { get; set; }
        public List<Organization> P_organization { get; set; }
        public List<Profile_biulding> P_Profile { get; set; }
        public List<fund_description> P_fund_dess { get; set; }
        public List<work_events> work_event { get; set; }
        public List<work_sub_cat> work_sub { get; set; }
        

    }
}