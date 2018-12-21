using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Controllers
{
    public class OLIWSController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        private ApplicationUser user = new ApplicationUser();
      
        // GET: OLIWS
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Donor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Donor(DonorViewModel don ,string prv, string nextbtn)
        {
            
            string new_id = "";
            if (ModelState.IsValid)
              
                {
                        new_id = Guid.NewGuid().ToString();
                        Fund_Type f_type = new Fund_Type()
                        {
                            Fund_TypeID=new_id,
                            Zakat = don.Zakat,
                            Sadaqah = don.Sadaqah,
                            Usher = don.Usher,
                            zakat_ul_fitr = don.zakat_ul_fitr,
                            khums = don.khums,
                            Atia_o_Khairat = don.Atia_o_Khairat

                        };
                        string fund = "";
                        fund = Guid.NewGuid().ToString();
                        Fund_Categories ff = new Fund_Categories()
                        {
                            Fund_CategoriesID = fund,
                            Education = don.Education,
                            Health = don.Health,
                            Loan=don.Other
                        };

                        string donor = "";
                        donor = Guid.NewGuid().ToString();
                        Donor dd = new Donor()
                        {
                            DonorID=fund,
                            Fund_TypeID=new_id,
                            frequency = don.frequency,
                            Amount = don.Amount

                        };
                        string account = "";
                        account = Guid.NewGuid().ToString();
                        Account acc = new Account()
                        {
                            AccountID=account,
                            DonorID = fund,
                            AccountName = don.AccountName,
                            duration = don.duration,
                            AccountNumber = don.AccountNumber,
                            SortCode = don.SortCode
                        };
                        //if ( TempData["mydata"]!=null )
                     
                        //db.organization.Add(org);
                        //db.SaveChanges();
                        db.fund_Type.Add(f_type);
                        db.SaveChanges();
                        db.fund_Categories.Add(ff);
                        db.SaveChanges();
                        db.donor.Add(dd);
                        db.SaveChanges();
                        db.account.Add(acc);
                        db.SaveChanges();

                    }

            return View();
        }
        public ActionResult Volunter()
        {
            var ff = db.Roles.Where(s => s.Name == "Volunteer").Select(t => t.Id).SingleOrDefault();
            if (ff == null)
            {
                string[] Role = new[] { "Donor", "Receiver", "Admin", "Team", "Volunteer" };
                for (int r = 0; r < Role.Length; r++)
                {
                    IdentityRole c = new IdentityRole();
                    c.Name = Role[r];
                    db.Roles.Add(c);
                    db.SaveChanges();
                }
            }
         return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Volunter(RegViewModel u, IdentityRole role)
        {
            try
            {
                string new_id = "";
                if (ModelState.IsValid)
                {
                    var vv = db.Roles.Where(s => s.Id == role.Id).Select(f => f.Name).SingleOrDefault();
                    new_id = Guid.NewGuid().ToString();
                    var user = new ApplicationUser { Id = new_id, UserName = u.Email, Email = u.Email,in_org=u.in_org, Category=vv, userStatus=u.userStatus, FirstName = u.FirstName, LastName = u.LastName, Phone = u.Phone, Gender = u.Gender, Date_of_birth = u.Date_of_birth, CNIC = u.CNIC, Address = u.Address, Muslim = u.Muslim, };

                    Session["use"] = user.Id;

                    var result = await UserManager.CreateAsync(user, u.Password);
                    IdentityUserRole U_role = new IdentityUserRole();
                    U_role.RoleId = role.Id;
                    U_role.UserId = user.Id;
                    db.Entry(U_role).State = EntityState.Added;
                    db.SaveChanges();
                    string profile_id = "";
                    profile_id = Guid.NewGuid().ToString();
                    Profile_biulding pro = new Profile_biulding()
                    {
                        Id = user.Id,
                        Profile_biuldingID = profile_id,
                        Qualification = u.qualification,
                        picture = "~/Images/user-33.jpg"
                    };

                    db.Profile.Add(pro);
                    db.SaveChanges();
                    return RedirectToAction("Volunteer", "Profile");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        public ActionResult Donate()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }
        public ActionResult Gallary()
        {
            return View();
        }
        public ActionResult Zakat()
        {
            return View();
        }
        public ActionResult Calculatezukat()
        {
            return View();
        }
        public ActionResult Usher()
        {
            return View();
        }

        public ActionResult Sadqa()
        {
            return View();
        }
        public ActionResult Fitrana()
        {
            return View();
        }
        public ActionResult Atia_o_Khairat()
        {
            return View();
        }
        public ActionResult Khums()
        {
            return View();
        }
        public ActionResult our_story()
        {
            return View();
        }
       
        public ActionResult organization_receiver()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult organization_receiver(OrgViewModel don)
        {
            try
            {
                string new_id = "";
                if (ModelState.IsValid)

                {

                    new_id = Guid.NewGuid().ToString();
                    Fund_Categories ff = new Fund_Categories()
                    {
                        Fund_CategoriesID = new_id,
                        Education = don.Education,
                        Health = don.Health,
                        Loan = don.Loan,
                        frequency = don.frequency
                    };
                    string fund = "";
                    fund = Guid.NewGuid().ToString();
                    Fund_sub_cat f_sub = new Fund_sub_cat()
                    {
                        Fund_sub_catID = fund,
                        AdmissionFee = don.AdmissionFee,
                        Uniform = don.Uniform,
                        Accessories = don.Accessories,
                        fee_cat = don.fee_cat,
                        semesterFee = don.semesterFee,
                        Annual = don.Annual,
                        stationary_cat = don.stationary_cat,
                        bags = don.bags,
                        books_notes = don.books_notes,
                        uniform_cat = don.uniform_cat,
                        Dress = don.Dress,
                        shoes = don.shoes,
                        Medicine = don.Medicine,
                        Minor_Surgury = don.Minor_Surgury,
                        Test_Reports = don.Test_Reports,
                        medi_cat = don.medi_cat
                    };
                    string f_dec = "";
                    f_dec = Guid.NewGuid().ToString();
                    fund_description fd = new fund_description()
                    {
                        fund_descriptionID = f_dec,
                        Fund_CategoriesID = new_id,
                        Fund_sub_catID = fund

                    };
                    string l = "";
                    l = Guid.NewGuid().ToString();
                    Loan ll = new Loan()
                    {
                        LoanID = l,
                        loan_amount = don.loan_amount,
                        Loan_Type = don.Loan_Type,
                        source_finance = don.source_finance
                    };

                    string rec = "";
                    rec = Guid.NewGuid().ToString();
                    Receiver dd = new Receiver()
                    {
                        ReceiverID = rec,
                        fund_descriptionID = f_dec,
                        LoanID = l,
                       
                        amount = don.amount
                    };
                    string account = "";
                    account = Guid.NewGuid().ToString();
                    Account acc = new Account()
                    {
                        AccountID = account,
                        ReceiverID = rec,
                    };
                    //if ( TempData["mydata"]!=null )

                    //db.organization.Add(org);
                    //db.SaveChanges();
                    db.fund_Categories.Add(ff);
                    db.SaveChanges();
                    db.fund_sub_cat.Add(f_sub);
                    db.SaveChanges();
                    db.fund_des.Add(fd);
                    db.SaveChanges();
                    db.loan.Add(ll);
                    db.SaveChanges();
                    db.receiver.Add(dd);
                    db.SaveChanges();
                    db.account.Add(acc);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home", new { msg = "registered" });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }

            return View();
        }

        public ActionResult Vision_And_Mission()
        {
            return View();
        }
        public ActionResult Our_structure()
        {
            return View();
        }
        public ActionResult newadd()
        {
           
            ViewBag.All_Roles = db.Roles.ToList();
            ViewBag.category = db.Roles.Where(x => x.Name != "Team").Where(d => d.Name != "Volunteer").Where(f => f.Name != "Admin").ToList();
            var ff = db.Roles.Where(s => s.Name == "Donor").Select(t => t.Id).SingleOrDefault();
            if (ff == null)
            {
                string[] Role = new[] { "Donor", "Receiver", "Admin", "Team", "Volunteer" };
                for (int r = 0; r < Role.Length; r++)
                {
                    IdentityRole c = new IdentityRole();
                    c.Name = Role[r];
                    db.Roles.Add(c);
                    db.SaveChanges();
                }
            }
            ViewBag.All_Roles = db.Roles.ToList();
            ViewBag.category = db.Roles.Where(x => x.Name != "Team").Where(d => d.Name != "Volunteer").Where(f => f.Name != "Admin").ToList();
            return View();
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> newadd(RegViewModel u, IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hh = db.Roles.Where(v => v.Id == role.Id).Select(f => f.Name).SingleOrDefault();
                    var user = new ApplicationUser { UserName = u.Email, Email = u.Email, in_org = u.in_org, FirstName = u.FirstName, Phone = u.Phone, Gender = u.Gender, Category = hh, Selected_city = u.Selected_city, Selected_Area = u.Selected_Area, Address = u.Address, Muslim = u.Muslim, userStatus = u.userStatus, };
                    //var result = await UserManager.CreateAsync(user, u.password);
                    {
                        Session["use"] = user.Id;
                        string orga = "";
                        orga = Guid.NewGuid().ToString();
                        Organization org = new Organization()
                        {
                            OrganizationID = orga,
                            Id = user.Id,
                            owner_Name = u.owner_Name,
                            owner_LastName = u.owner_LastName,
                            owner_CNIC = u.owner_CNIC,
                            owner_Address = u.owner_Address,
                            owner_PhoneNum = u.owner_PhoneNum,
                            owner_Email = u.owner_Email
                        };
                        string fund = "";
                        fund = Guid.NewGuid().ToString();
                        Fund_Categories ff = new Fund_Categories()
                        {
                            Fund_CategoriesID = fund,
                            Education = u.Education,
                            Health = u.Health,
                            Loan = u.Other,
                            frequency = u.frequency
                        };
                       

                        if (hh == "Donor")
                        {

                            string fu = Guid.NewGuid().ToString();
                            Fund_Type f_type = new Fund_Type()
                            {
                                Fund_TypeID = fu,
                                Zakat = u.Zakat,
                                Sadaqah = u.Sadaqah,
                                Usher = u.Usher,
                                zakat_ul_fitr = u.zakat_ul_fitr,
                                khums = u.khums,
                                Atia_o_Khairat = u.Atia_o_Khairat

                            };
                            string f_dec = "";
                            f_dec = Guid.NewGuid().ToString();
                            fund_description fd = new fund_description()
                            {
                                fund_descriptionID = f_dec,
                                Fund_CategoriesID = ff.Fund_CategoriesID
                            };

                            string donor = "";
                            donor = Guid.NewGuid().ToString();
                            Donor dd = new Donor()
                            {
                                Id = user.Id,
                                DonorID = fund,
                                Fund_TypeID = fu,
                               
                                Amount = u.Amount,
                                 fund_descriptionID = f_dec
                            };
                            string account = "";
                            account = Guid.NewGuid().ToString();
                            Account acc = new Account()
                            {
                                AccountID = account,
                                DonorID = fund,
                                AccountName = u.AccountName,
                                duration = u.duration,
                                AccountNumber = u.AccountNumber,
                                SortCode = u.SortCode
                            };
                            var result = await UserManager.CreateAsync(user, u.Password);
                            db.organization.Add(org);
                            db.SaveChanges();
                            db.fund_Type.Add(f_type);
                            db.SaveChanges();
                            db.fund_Categories.Add(ff);
                            db.SaveChanges();
                            db.fund_des.Add(fd);
                            db.SaveChanges();
                            db.donor.Add(dd);
                            db.SaveChanges();
                            db.account.Add(acc);
                            db.SaveChanges();
                            IdentityUserRole U_role = new IdentityUserRole();
                            U_role.RoleId = role.Id;
                            U_role.UserId = user.Id;
                            db.Entry(U_role).State = EntityState.Added;
                            db.SaveChanges();

                            string profile_id = "";
                            profile_id = Guid.NewGuid().ToString();
                            Profile_biulding pro = new Profile_biulding()
                            {
                                Id = user.Id,
                                Profile_biuldingID = profile_id,
                                picture = "~/Images/user-33.jpg"
                            };

                            db.Profile.Add(pro);
                            db.SaveChanges();
                            return RedirectToAction("DonorOrganisation", "Profile");
                        }
                        else if (hh == "Receiver")
                        {


                            string fund_sub = "";
                            fund_sub = Guid.NewGuid().ToString();
                            Fund_sub_cat f_sub = new Fund_sub_cat()
                            {
                                Fund_sub_catID = fund_sub,
                                AdmissionFee = u.AdmissionFee,
                                Uniform = u.Uniform,
                                Accessories = u.Accessories,
                                fee_cat = u.fee_cat,
                                semesterFee = u.semesterFee,
                                Annual = u.Annual,
                                bags = u.bags,
                                books_notes = u.books_notes,
                                Dress = u.Dress,
                                Medicine = u.Medicine,
                                Minor_Surgury = u.Minor_Surgury,
                                Test_Reports = u.Test_Reports,
                                medi_cat = u.medi_cat
                            };
                            string f_dec = "";
                            f_dec = Guid.NewGuid().ToString();
                            fund_description fd = new fund_description()
                            {
                                fund_descriptionID = f_dec,
                                Fund_CategoriesID = ff.Fund_CategoriesID,
                                Fund_sub_catID = fund_sub

                            };
                            string l = "";
                            l = Guid.NewGuid().ToString();
                            Loan ll = new Loan()
                            {
                                LoanID = l,
                                loan_amount = u.loan_amount,
                                Loan_Type = u.Loan_Type,
                                source_finance = u.source_finance
                            };

                            string rec = "";
                            rec = Guid.NewGuid().ToString();
                            Receiver dd = new Receiver()
                            {
                                Id = user.Id,
                                ReceiverID = rec,
                                fund_descriptionID = f_dec,
                                LoanID = l,
                                amount = u.HealthAmount

                            };
                            string account = "";
                            account = Guid.NewGuid().ToString();
                            Account a = new Account()
                            {
                                AccountID = account,
                                ReceiverID = rec,
                            };
                            var result = await UserManager.CreateAsync(user, u.Password);
                            db.organization.Add(org);
                            db.SaveChanges();
                            db.fund_Categories.Add(ff);
                            db.SaveChanges();
                            db.fund_sub_cat.Add(f_sub);
                            db.SaveChanges();
                            db.fund_des.Add(fd);
                            db.SaveChanges();
                            db.loan.Add(ll);
                            db.SaveChanges();
                            db.receiver.Add(dd);
                            db.SaveChanges();
                            db.account.Add(a);
                            db.SaveChanges();
                            IdentityUserRole U_role = new IdentityUserRole();
                            U_role.RoleId = role.Id;
                            U_role.UserId = user.Id;
                            db.Entry(U_role).State = EntityState.Added;
                            db.SaveChanges();
                            string profile_id = "";
                            profile_id = Guid.NewGuid().ToString();
                            Profile_biulding pro = new Profile_biulding()
                            {
                                Id = user.Id,
                                Profile_biuldingID = profile_id,
                                 picture = "~/Images/user-33.jpg"
                            };

                            db.Profile.Add(pro);
                            db.SaveChanges();
                            return RedirectToAction("ReceiverOrganisation", "Profile");

                        }
                    }
                   }
                //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        public ActionResult Work_with_us()
        {
            return View();
        }
        public ActionResult contact_us()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult contact_us(conViewModel co)
        {  

                        string contact = "";
                        if (ModelState.IsValid)
                        {
                            contact = Guid.NewGuid().ToString();
                            Contact_us con = new Contact_us()
                            {
                                Contact_usID = contact,
                                name = co.name,
                                lastname = co.lastname,
                                Message = co.Message,
                                con_Email=co.con_Email,
                                subject = co.subject

                            };

                            db.contact_us.Add(con);
                            db.SaveChanges();
                            return RedirectToAction("Index", "Home", new { msg = "registered" });
                        }
                        // If we got this far, something failed, redisplay form
                                return View();
                            }

        public ActionResult receiver()
        {
            return View();
        }






























        //[NonAction]
        //public void getingData()
        //{
        //    List<Role> cat = new List<Role>();
        //    cat = db.role.Where(a => a.status == "true").ToList();
        //    cat.Insert(0, new Role { RoleID = "", Role_Name = "Select Type" });
        //    if (cat != null)
        //    {
        //        ViewBag.RoleName = new SelectList(cat, "RoleID", "Role_Name");
        //    }
        //}







    }

}