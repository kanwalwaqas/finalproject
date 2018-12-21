using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Drawing;
using System.IO;
using OLIWS.Areas.Admin.Models;

namespace OLIWS.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {

        private ProfileViewModel obj;
    public   AdminController()
        {
            obj = new ProfileViewModel
            {
                work_event = db.work_event.ToList(),
                work_sub=db.work_sub.ToList()

            };
        }
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult indexdata()
        {
            return View();
        }
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult indexdata(Fund_Categories f_cat, HttpPostedFileBase file, volunteer vol, HttpPostedFileBase file1, Team tm, HttpPostedFileBase file2)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        string f_id = Guid.NewGuid().ToString();
        //        string v_id = Guid.NewGuid().ToString();
        //        string t_id = Guid.NewGuid().ToString();
        //        f_cat.Fund_CategoriesID = f_id;
        //        f_cat.cat_img = filepathgetter(file);
        //        db.fund_Categories.Add(f_cat);
        //        db.SaveChanges();
        //        vol.volunteerID = v_id;
        //        vol.vol_img = filepathgetter(file1);
        //        db.Volunteer.Add(vol);
        //        db.SaveChanges();
        //        tm.TeamID = t_id;
        //        tm.team_img = filepathgetter(file2);
        //        db.team.Add(tm);
        //        db.SaveChanges();


        //    }
        //    return View();
        //}

        private string filepathgetter(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                return Path_Genarator(file);
            }
            else
            {
                return null;
            }
        }


        public ActionResult eventsdetail()
        {
            return View(obj);
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
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        public ActionResult team()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> team(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                       string new_id = Guid.NewGuid().ToString();
                        var user = new ApplicationUser {Id= new_id, UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Phone = model.Phone, Date_of_birth = model.Date_of_birth, CNIC = model.CNIC, Address = model.Address, };
                   // var result = await UserManager.CreateAsync(user, model.Password);
                    
                    
                       // await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                       
                         Session["use"] = user.Id;

                        string volun = "";
                        volun = Guid.NewGuid().ToString();
                        Team vol = new Team()
                        {
                            TeamID = volun,
                            Id = new_id,
                            experience = model.qualification

                        };
                        db.Users.Add(user);
                        db.SaveChanges();

                        db.team.Add(vol);
                        db.SaveChanges();
                        string profile_id = "";
                        profile_id = Guid.NewGuid().ToString();
                        Profile_biulding pro = new Profile_biulding()
                        {
                            Id = user.Id,
                            Profile_biuldingID = profile_id
                        };

                        db.Profile.Add(pro);
                        db.SaveChanges();
                        //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                        return Redirect("http://localhost:56466/Profile/Volunteer");
                      
                    }
                   
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public ActionResult UserDetail()
        {
            return View(db.Users.ToList());
        }
        public ActionResult eventstatus(string id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_events work_events = db.work_event.Find(id);
            if (work_events == null)
            {
                return HttpNotFound();
            }
           
            return View(work_events);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult eventstatus([Bind(Include = "work_eventsID,events,campigns,news,notification,IsActive")] work_events work_events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_events);
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

        public ActionResult Userblock(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/ApplicationUsers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Userblock([Bind(Include = "Id,FirstName,LastName,Phone,Gender,Date_of_birth,CNIC,Selected_city,Selected_Area,Address,Muslim,Category,userStatus,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }
        public ActionResult newsfeed()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newsfeed(conViewModel u, HttpPostedFileBase file)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (file != null && file.ContentLength > 0)

                    {

                        u.event_image = Path_Genarator(file);
                    }

                    {
                        string voll = "";
                        voll = Guid.NewGuid().ToString();
                        work_events volm = new work_events()
                        {
                            work_eventsID = voll,
                            events = u.events,
                            IsActive = u.IsActive

                        };
                        string volun = "";
                        volun = Guid.NewGuid().ToString();
                        work_sub_cat vol = new work_sub_cat()
                        {
                            work_sub_catID = volun,
                            work_eventsID = voll,
                            Title = u.Title,
                            Description = u.Description,
                            Number = u.Number,

                            Date = u.Date,
                            Name = u.name,
                            detail = u.detail,
                            Venue = u.Venue,
                            event_image=u.event_image
                            




                        };


                        db.work_event.Add(volm);
                        db.SaveChanges();
                        db.work_sub.Add(vol);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        public ActionResult ApproveRequest(String id)
        {

            ApplicationDbContext db = new ApplicationDbContext();
            var rec = db.receiver.Where(w => w.ReceiverID == id).FirstOrDefault();
            var user = db.Users.Where(w => w.Id == rec.Id).FirstOrDefault();

            ApprovalItems resultedItem = new ApprovalItems();
            resultedItem.Status = rec.status == null ? "Not Approved!" : "Approved";
            resultedItem.Name = user.FirstName;
            resultedItem.Contact = user.Phone;
            resultedItem.Email = user.Email;
            resultedItem.ReceiverID = id;
            resultedItem.RequiredForEducation = rec.fund_description.fund_Categories.Education;
            resultedItem.RequiredForHealth = rec.fund_description.fund_Categories.Health;
            resultedItem.RequiredForothers = rec.fund_description.fund_Categories.Loan;

            if (resultedItem.RequiredForothers != null)
            {

                var gaurdianDetails = db.gaurdianInformation.Where(w => w.RecieverID == id).First();
                resultedItem.GaudianKey = gaurdianDetails.GaudianKey;
                resultedItem.Gardian_Name = gaurdianDetails.Gardian_Name;
                resultedItem.Gardian_Members = gaurdianDetails.Gardian_Members;
                resultedItem.Gardian_Income = gaurdianDetails.Gardian_Income;
                resultedItem.Gardian_Occupation = gaurdianDetails.Gardian_Occupation;
                resultedItem.Gardian_Oranization = gaurdianDetails.Gardian_Oranization;

            }

            resultedItem.RequiredAmount = rec.amount;
            resultedItem.frequency = rec.fund_description.fund_Categories.frequency;
            resultedItem.AdmissionFee = rec.fund_description.fund_sub_cat.AdmissionFee;
            resultedItem.Uniform = rec.fund_description.fund_sub_cat.Uniform;
            resultedItem.Accessories = rec.fund_description.fund_sub_cat.Accessories;
            resultedItem.fee_cat = rec.fund_description.fund_sub_cat.fee_cat;
            resultedItem.semesterFee = rec.fund_description.fund_sub_cat.semesterFee;
            resultedItem.Annual = rec.fund_description.fund_sub_cat.Annual;
            resultedItem.Minor_Surgury = rec.fund_description.fund_sub_cat.Minor_Surgury;
            resultedItem.Medicine = rec.fund_description.fund_sub_cat.Medicine;
            resultedItem.Test_Reports = rec.fund_description.fund_sub_cat.Test_Reports;

            return View(resultedItem);
        }

        [HttpPost]
        public ActionResult ProcessRecieverRequests(HTTPAprovelRequest request)
        {

            ApplicationDbContext db = new ApplicationDbContext();

            var item = db.receiver.Where(w => w.ReceiverID == request.RecieverID).FirstOrDefault();
            var user = db.Users.Where(w => w.Id == item.Id).FirstOrDefault();
            ResponseResult response = new ResponseResult();

            float HealthDeducted = 0;
            float OthersDeducted = 0;
            float EducationDeducted = 0;

            var rectraverse = db.receiver.Where(w => w.status != null).ToList();

            foreach (var it in rectraverse)
            {

                if (item.fund_description.fund_Categories.Education != null)
                {
                    OthersDeducted += float.Parse(it.amount);
                }
                if (item.fund_description.fund_Categories.Health != null)
                {
                    HealthDeducted += float.Parse(it.amount);
                }
                if (item.fund_description.fund_Categories.Loan != null)
                {
                    EducationDeducted += float.Parse(it.amount);
                }

            }


            if (item.fund_description.fund_Categories.Education != null)
            {

                float availableAmount = db.balanceDetails.Sum(s => s.Education) - EducationDeducted;
                if (availableAmount >= float.Parse(request.AmountRequested))
                {
                    item.status = "Approved";
                    db.SaveChanges();
                    response.status = "200";
                    response.message = "Successfully Approved!";
                    response.result = "done";
                }
                else
                {
                    response.status = "202";
                    response.message = "Your Balance is less than Request.";
                    response.result = "done";
                }
            }
            if (item.fund_description.fund_Categories.Health != null)
            {

                float availableAmount = db.balanceDetails.Sum(s => s.Health) - HealthDeducted;
                if (availableAmount >= float.Parse(request.AmountRequested))
                {
                    item.status = "Approved";
                    db.SaveChanges();
                    response.status = "200";
                    response.message = "Successfully Approved!";
                    response.result = "done";
                }
            }
            if (item.fund_description.fund_Categories.Loan != null)
            {

                float availableAmount = db.balanceDetails.Sum(s => s.Others) - OthersDeducted;
                if (availableAmount >= float.Parse(request.AmountRequested))
                {
                    item.status = "Approved";
                    db.SaveChanges();
                    response.status = "200";
                    response.message = "Successfully Approved !";
                    response.result = "done";
                }
                else
                {
                    response.status = "202";
                    response.message = "Your Balance is less than Request.";
                    response.result = "done";
                }
            }

            return Json(response);
        }


        public ActionResult AvailableBalanceReports()
        {

            ApplicationDbContext db = new ApplicationDbContext();

            BalanceReport report = new BalanceReport();



            var rec = db.receiver.Where(w => w.status != null).ToList();

            float HealthDeducted = 0;
            float OthersDeducted = 0;
            float EducationDeducted = 0;

            foreach (var item in rec)
            {
                RecieverReports reportItem = new RecieverReports();
                var user = db.Users.Where(w => w.Id == item.Id).FirstOrDefault();
                reportItem.Name = user.FirstName;
                reportItem.Contact = user.Phone;
                reportItem.Email = user.Email;
                reportItem.Status = item.status == null ? "Not Approved!" : "Approved";
                reportItem.RequiredAmount = item.amount;

                if (item.fund_description.fund_Categories.Education != null)
                {
                    OthersDeducted += float.Parse(item.amount);
                }
                if (item.fund_description.fund_Categories.Health != null)
                {
                    HealthDeducted += float.Parse(item.amount);
                }
                if (item.fund_description.fund_Categories.Loan != null)
                {
                    EducationDeducted += float.Parse(item.amount);
                }

            }


            report.TotalAmount = (db.balanceDetails.Sum(s => s.TotalAmount) - EducationDeducted - HealthDeducted - OthersDeducted).ToString();
            report.Education = db.balanceDetails.Sum(s => s.Education - EducationDeducted).ToString();
            report.Health = db.balanceDetails.Sum(s => s.Health - HealthDeducted).ToString();
            report.Others = db.balanceDetails.Sum(s => s.Others - OthersDeducted).ToString();
            report.Team = db.balanceDetails.Sum(s => s.Team).ToString();
            report.Admin = db.balanceDetails.Sum(s => s.Admin).ToString();

            return View(report);
        }

        public ActionResult RecieverReports()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<RecieverReports> listItems = new List<RecieverReports>();
            var rec = db.receiver.ToList();
            foreach (var item in rec)
            {
                RecieverReports reportItem = new RecieverReports();
                var user = db.Users.Where(w => w.Id == item.Id).FirstOrDefault();
                reportItem.ReceiverID = item.ReceiverID;
                reportItem.Name = user.FirstName;
                reportItem.Contact = user.Phone;
                reportItem.Email = user.Email;
                reportItem.Status = item.status == null ? "Not Approved!" : "Approved";
                reportItem.RequiredAmount = item.amount;

                reportItem.RequiredForEducation = item.fund_description.fund_Categories.Education;
                reportItem.RequiredForHealth = item.fund_description.fund_Categories.Health;
                reportItem.RequiredForothers = item.fund_description.fund_Categories.Loan;

                listItems.Add(reportItem);
            }

            return View(listItems);
        }

        public ActionResult VolunteerReports()
        {

            ApplicationDbContext db = new ApplicationDbContext();
            List<VolunteerReport> listItems = new List<VolunteerReport>();
            var volunteer = db.Roles.Where(s=>s.Name== "Volunteer").Select(l=>l.Users.Select(p=>p.UserId)).SingleOrDefault();
            foreach (var item in volunteer)
            {
                VolunteerReport reportItem = new VolunteerReport();
                var user = db.Users.Where(w => w.Id == item).FirstOrDefault();
                reportItem.Name = user.FirstName;
                reportItem.ContactInfortamtion = user.Phone;
                reportItem.Description = db.Profile.FirstOrDefault(h=>h.Id==user.Id).Qualification;
                reportItem.EmailAddress = user.Email;
                listItems.Add(reportItem);
            }

            return View(listItems);
        }

        public ActionResult DonationReports()
        {
            List<DonationsReport> listItems = new List<DonationsReport>();

            ApplicationDbContext db = new ApplicationDbContext();
            var results = db.balanceDetails.ToList();
            foreach (var item in results)
            {
                DonationsReport reportData = new DonationsReport();
                reportData.Health = item.Health.ToString();
                reportData.Education = item.Education.ToString();
                reportData.Loan = item.Others.ToString();
                reportData.SubmittedDate = item.dateInformation;
                reportData.Donor = db.Users.Where(w => w.Id == item.UserID).Select(s => s.FirstName).FirstOrDefault();
                listItems.Add(reportData);
            }

            return View(listItems);

        }

    }
}