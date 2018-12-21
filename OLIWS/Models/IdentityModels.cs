using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace OLIWS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Date_of_birth { get; set; }
        public string CNIC { get; set; }
      
        public string Selected_city { get; set; }
       
        public string Selected_Area { get; set; }
        public string Address { get; set; }
        public string Muslim { get; set; }
        public string in_org { get; set; }
        public string Category { get; set; }
        public bool userStatus { get; set; }
        public DateTime currentDate { get; set; }
        public string image { get; set; }
        public string fund_type { get; set; }
        public ApplicationUser()
        {
            currentDate = DateTime.Now;
        }
       // public string Date { get; set; }
 public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            
                                               // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Banner> Dbbanner { get; set; }
       public DbSet<Account> account { get; set; }
        public DbSet<Donor>donor { get; set; }
        public DbSet<Fund_Categories> fund_Categories { get; set; }
        public DbSet<Fund_Type> fund_Type { get; set; }
        public DbSet<Loan> loan { get; set; }
        public DbSet<Fund_sub_cat> fund_sub_cat { get; set; }
        public DbSet<work_events> work_event { get; set; }
        public DbSet<Registration_type> registration_type { get; set; }
        public DbSet<Receiver> receiver { get; set; }
        public DbSet<Report> report { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Team> team { get; set; }
        public DbSet<Organization> organization { get; set; }
        public DbSet<Profile_biulding> Profile { get; set; }
        public DbSet<fund_description> fund_des { get; set; }
        public DbSet<work_sub_cat> work_sub { get; set; }
        public DbSet<Contact_us> contact_us { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<BalanceDetails> balanceDetails { get; set; }
        public DbSet<GaudianInformation> gaurdianInformation { get; set; }
        public DbSet<team_asigned_jobs> tm_job_assign { get; set; }
        public DbSet<Campaigns> campaigns { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}