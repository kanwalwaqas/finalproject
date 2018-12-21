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

namespace OLIWS.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
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
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult indexdata(conViewModel u, HttpPostedFileBase file)
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
                        Fund_Categories vel = new Fund_Categories()
                        {
                            Fund_CategoriesID = voll,
                            cat_img = u.cat_img,
                            cat_title = u.cat_title,
                            cat_decsription = u.cat_decsription



                        };
                        string voo = "";
                        voo = Guid.NewGuid().ToString();
                        volunteer voe = new volunteer()
                        {
                            volunteerID = voo,

                            vol_title = u.vol_title,
                            vol_description = u.vol_description,
                            vol_img = u.vol_img

                        };
                        string vao = "";
                        vao = Guid.NewGuid().ToString();
                        Team vii = new Team()
                        {
                            TeamID = vao,

                            team_img = u.team_img,
                            team_title = u.team_title,
                            team_description = u.team_description


                        };
                        db.fund_Categories.Add(vel);
                        db.SaveChanges();
                        db.team.Add(vii);
                        db.SaveChanges();
                        db.Volunteer.Add(voe);
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

        
        public ActionResult eventsdetail()
        {
            return View(db.work_event.ToList());
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

                        return RedirectToAction("Volunteer", "Profile");
                      
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


    }
}