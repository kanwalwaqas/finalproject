using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OLIWS.Models;
using System.IO;
using System.Drawing;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace OLIWS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ApplicationDbContext db = new ApplicationDbContext();
        IdentityUserRole i = new IdentityUserRole();
        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
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
        public ActionResult blockuser()
        {
            return View();
        }
        public ActionResult Receiver()
        {
            return View();
        }
        private string Path_Genarator(HttpPostedFileBase file)

        {
            var fileName = Path.GetFileName(file.FileName);
            var paths = Path.Combine(Server.MapPath("/Images/"), fileName);
            file.SaveAs(paths);
            //evidence_Submission_Detail.File = paths;                             
            string fl = paths.Substring(paths.LastIndexOf("\\"));
            string[] split = fl.Split('\\');
            string newpath = split[1];
            string imagepath = "~/Images/" + newpath;
            return imagepath;
            Image i = System.Drawing.Image.FromFile(paths);
            i.RotateFlip(RotateFlipType.Rotate90FlipXY);

        }
        public ActionResult Email_confirmation(string user_Email, string user_id)
        {
            //if (user_Email == null)
            //{
            //    return View("Error");
            //}
            ViewBag.Email = user_Email;
            ViewBag.Id = user_id;
            return View();
        }
       
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(/*db.Users.ToList()*/);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            //switch (result)
            //{
            if (SignInStatus.Success == result)
            {
                var user = await UserManager.FindAsync(model.Email, model.Password);
                Session["use"] = user.Id;
                //if(user.EmailConfirmed==false)
                //{
                //    return RedirectToAction("Email_confirmation", "Account");
                //}

                if (user.userStatus == false)
                {
                    return RedirectToAction("blockuser", "Account");
                }

                if (user.Category==("Donor") && user.in_org == ("Individual"))
                {
                    return RedirectToAction("Userprofile", "Profile");
                }
                else if (user.Category==("Receiver") && user.in_org == ("Individual"))
                {
                    return RedirectToAction("ReceiverIndividual", "Profile");
                }
                else if (user.Category == ("Donor") && user.in_org == ("Organization"))
                {
                    return RedirectToAction("DonorOrganisation", "Profile");
                }
                else if (user.Category==("Receiver") && user.in_org == ("Organization"))
                {
                    return RedirectToAction("ReceiverOrganisation", "Profile");
                }
                else if (user.Category==("Volunteer"))
                {
                    return RedirectToAction("Volunteer", "Profile");
                }
                else
                {
                    return View();
                }
            }
            //return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:
            //        ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
            
        }


        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
       
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.GetUserId() != null)
            {
                return RedirectToAction("Userprofile", "Profile");
            }
            ViewBag.All_Roles = db.Roles.ToList();
            ViewBag.category= db.Roles.Where(x => x.Name != "Team").Where(d => d.Name != "Volunteer").Where(f => f.Name != "Admin").ToList();
            var ff = db.Roles.Where(s => s.Name == "Donor").Select(t => t.Id).SingleOrDefault();
            if (ff == null)
            {
                string[] Role = new[] { "Donor", "Receiver", "Admin" ,"Team","Volunteer"};
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

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, HttpPostedFileBase file, IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var paths = Path.Combine(Server.MapPath("/Images/"), fileName);
                    file.SaveAs(paths);
                }
                try
                {
                    var u = db.Roles.Where(s => s.Id == role.Id).Select(f => f.Name).SingleOrDefault();
                    string m;
                    m = Guid.NewGuid().ToString();
                    var user = new ApplicationUser { Id = m, in_org = model.in_org, UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Phone = model.Phone, Gender = model.Gender, Date_of_birth = model.Date_of_birth, CNIC = model.CNIC, Selected_city = model.Selected_city, Selected_Area = model.Selected_Area, Address = model.Address, Category = u, Muslim = model.Muslim, userStatus = model.userStatus, image = model.image };


                    // if (result.Succeeded)
                    {

                        Session["use"] = user.Id;
                        Session["Role"] = u;

                        //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        Session["use"] = user.Id;

                        //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        if (u == "Donor")
                        {
                            string new_id = "";
                            new_id = Guid.NewGuid().ToString();
                            Fund_Type f_type = new Fund_Type()
                            {
                                Fund_TypeID = new_id,
                                Zakat = model.Zakat,
                                Sadaqah = model.Sadaqah,
                                Usher = model.Usher,
                                zakat_ul_fitr = model.zakat_ul_fitr,
                                khums = model.khums,
                                Atia_o_Khairat = model.Atia_o_Khairat

                            };
                            Session["fund"] = f_type.Fund_TypeID;
                            string fund = "";
                            fund = Guid.NewGuid().ToString();
                            Fund_Categories ff = new Fund_Categories()
                            {
                                Fund_CategoriesID = fund,
                                Education = model.Education,
                                Health = model.Health,
                                Loan = model.Other,
                                frequency = model.frequency
                            };
                            Session["fundcat"] = ff.Fund_CategoriesID;
                            string f_dec = "";
                            f_dec = Guid.NewGuid().ToString();
                            fund_description fd = new fund_description()
                            {
                                fund_descriptionID = f_dec,
                                Fund_CategoriesID = fund,

                            };
                            Session["funddes"] = fd.fund_descriptionID;
                            string donor = "";
                            donor = Guid.NewGuid().ToString();
                            Donor dd = new Donor()
                            {
                                Id = m,
                                DonorID = fund,
                                Fund_TypeID = new_id,
                                frequency = model.frequency,
                                Amount = model.Amount,
                                fund_descriptionID = f_dec,

                            };
                            Session["donor"] = dd.DonorID;
                            //string account = "";
                            //account = Guid.NewGuid().ToString();
                            //Account acc = new Account()
                            //{
                            //    AccountID = account,
                            //    DonorID = fund,
                            //    AccountName = model.AccountName,
                            //    duration = model.duration,
                            //    AccountNumber = model.AccountNumber,
                            //    SortCode = model.SortCode
                            //};

                            var result = await UserManager.CreateAsync(user, model.Password);
                            db.fund_Type.Add(f_type);
                            //db.SaveChanges();
                            db.fund_Categories.Add(ff);
                            //db.SaveChanges();
                            db.fund_des.Add(fd);
                            //db.SaveChanges();
                            db.donor.Add(dd);
                            //db.SaveChanges();
                            string profile_id = "";
                            IdentityUserRole U_role = new IdentityUserRole();
                            U_role.RoleId = role.Id;
                            U_role.UserId = user.Id;
                            db.Entry(U_role).State = EntityState.Added;
                            //db.SaveChanges();
                            profile_id = Guid.NewGuid().ToString();
                            Profile_biulding pro = new Profile_biulding()
                            {
                                Id = user.Id,
                                Profile_biuldingID = profile_id,
                                personal_info = u,
                                picture = "~/Images/user-33.jpg"
                            };


                            // This code block  is to update  data for reports 
                            //if you want to  change percentage please change these values
                            double deductedPercnetageOthers = 15;
                            double deductedPercnetageHealth = 35;
                            double deductedPercnetageEducation = 50;


                            BalanceDetails balance = new BalanceDetails();
                            balance.BalanceID = Guid.NewGuid().ToString();
                            double totalValue = Convert.ToDouble(model.Amount);
                            double adminPercentage = (totalValue / 100) * 5;
                            double teamPercentage = (totalValue / 100) * 2;

                            double totalAfterDeduction = totalValue - adminPercentage - teamPercentage;
                            balance.dateInformation = DateTime.Now.ToString();
                            balance.TotalAmount = (float)totalAfterDeduction;
                            balance.Admin = (float)adminPercentage;
                            balance.Team = (float)teamPercentage;
                            if ((model.Education == "Education") && (model.Health == "Health") && (model.Other == "Other"))
                            {
                                balance.Others = (float)((deductedPercnetageOthers / 100.0) * totalAfterDeduction);
                                balance.Health = (float)((deductedPercnetageHealth / 100.0) * totalAfterDeduction);
                                balance.Education = (float)((deductedPercnetageEducation / 100.0) * totalAfterDeduction);
                            }
                            else if ((model.Education == "Education") && (model.Health == "Health") && (model.Other == null))
                            {
                                balance.Others = 0;
                                balance.Health = (float)((deductedPercnetageHealth / 100.0) * totalAfterDeduction);
                                balance.Education = (float)((deductedPercnetageEducation / 100.0) * totalAfterDeduction);
                            }
                            else if ((model.Education == "Education") && (model.Health == null) && (model.Other == "Other"))
                            {
                                balance.Others = (float)((50 / 100.0) * totalAfterDeduction);
                                balance.Health = 0;
                                balance.Education = (float)((50 / 100.0) * totalAfterDeduction);
                            }
                            else if ((model.Education == null) && (model.Health == "Health") && (model.Other == "Other"))
                            {
                                balance.Others = (float)((50 / 100.0) * totalAfterDeduction);
                                balance.Health = (float)((50 / 100.0) * totalAfterDeduction);
                                balance.Education = 0;
                            }
                            else if ((model.Education == null) && (model.Health == "Health") && (model.Other == null))
                            {
                                balance.Others = 0;
                                balance.Health = (float)((50 / 100.0) * totalAfterDeduction);
                                balance.Education = 0;
                            }
                            else if ((model.Education == "Education") && (model.Health == null) && (model.Other == null))
                            {
                                balance.Others = 0;
                                balance.Health = 0;
                                balance.Education = (float)totalAfterDeduction;
                            }
                            else if ((model.Education == null) && (model.Health == null) && (model.Other == "Other"))
                            {
                                balance.Others = (float)totalAfterDeduction;
                                balance.Health = 0;
                                balance.Education = 0;
                            }
                            balance.dateInformation = DateTime.Now.ToString();
                            balance.UserID = m;
                            balance.DonorID = fund;
                            db.balanceDetails.Add(balance);
                            //db.SaveChanges();
                            db.Profile.Add(pro);
                            db.SaveChanges();

                            //db.account.Add(acc);
                            //db.SaveChanges();
                            return RedirectToAction("Userprofile", "Profile");
                        }
                        else if (u == "Receiver")
                        {

                            string fund_sub = "";
                            fund_sub = Guid.NewGuid().ToString();
                            Fund_sub_cat f_sub = new Fund_sub_cat()
                            {
                                Fund_sub_catID = fund_sub,
                                AdmissionFee = model.AdmissionFee,
                                Uniform = model.Accessories,
                                Accessories = model.Uniform,
                                fee_cat = model.stationary_cat,
                                semesterFee = model.fee_cat,
                                Annual = model.uniform_cat,
                                Minor_Surgury = model.Minor_Surgury,
                                Medicine = model.Medicine,
                                Test_Reports = model.Test_Reports

                            };
                            string fund = "";
                            fund = Guid.NewGuid().ToString();
                            String categories = model.Other;
                            if (model.reciever_fund_type == "Loan")
                            {
                                categories = "Loan";
                            }
                            Fund_Categories ff = new Fund_Categories()
                            {
                                Fund_CategoriesID = fund,
                                frequency = model.frequency_educ,
                                Education = model.Education,
                                Health = model.Health,
                                Loan = categories
                            };
                            string f_dec = "";
                            f_dec = Guid.NewGuid().ToString();
                            fund_description fd = new fund_description()
                            {
                                fund_descriptionID = f_dec,
                                Fund_CategoriesID = fund,
                                Fund_sub_catID = fund_sub
                            };
                            string rec = "";

                            rec = Guid.NewGuid().ToString();
                            Receiver dd = new Receiver()
                            {
                                ReceiverID = rec,
                                Id = m,
                                fund_descriptionID = f_dec,
                                amount = model.reciever_fund_type == "Loan" ? model.Loan_Amount : model.HealthAmount
                            };

                            if (model.reciever_fund_type == "Loan")
                            {

                                GaudianInformation gaurdianInformation = new GaudianInformation();
                                gaurdianInformation.GaudianKey = Guid.NewGuid().ToString();
                                gaurdianInformation.UserID = m;
                                gaurdianInformation.RecieverID = rec;
                                gaurdianInformation.Gardian_Name = model.Gardian_Name;
                                gaurdianInformation.Gardian_Members = model.Gardian_Members;
                                gaurdianInformation.Gardian_Occupation = model.Gardian_Occupation;
                                gaurdianInformation.Gardian_Oranization = model.Gardian_Oranization;
                                gaurdianInformation.Gardian_Income = model.Gardian_Income;
                                gaurdianInformation.Loan_Amount = model.Loan_Amount;

                                db.gaurdianInformation.Add(gaurdianInformation);
                                db.SaveChanges();
                            }

                            var result = await UserManager.CreateAsync(user, model.Password);
                            db.fund_Categories.Add(ff);
                            db.SaveChanges();
                            db.fund_sub_cat.Add(f_sub);
                            db.SaveChanges();
                            db.fund_des.Add(fd);
                            db.SaveChanges();
                            db.receiver.Add(dd);
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
                                personal_info = u
                            };

                            db.Profile.Add(pro);
                            db.SaveChanges();
                        }

                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");


                        //}

                        return RedirectToAction("ReceiverIndividual", "Profile");

                        //AddErrors(result);
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }

            }
            ViewBag.All_Roles = db.Roles.ToList();
            ViewBag.category = db.Roles.Where(x => x.Name != "Team").Where(d => d.Name != "Volunteer").Where(f => f.Name != "Admin").ToList();
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                 string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Session.Clear();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}