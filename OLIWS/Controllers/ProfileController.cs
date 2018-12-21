using Microsoft.AspNet.Identity;
using OLIWS.Areas.Admin.Models;
using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext db;
        private ProfileViewModel obj;

        public object RotateFlipType { get; private set; }

        public ProfileController()
        {
            db = new ApplicationDbContext();
        }
        public ProfileViewModel result()
        {
            var uu = User.Identity.GetUserId();
            if (uu != null)
            {
                var user = db.Users.Where(a => a.Id == uu.ToString());
                var pro = db.Profile.Where(w => w.Id == uu.ToString());
                var org = db.organization.Where(w => w.Id == uu.ToString());
                //var don = db.donor.Where(u => u.Id == uu.ToString()).ToList();
                var type = Session["fund"] as string;
                var donate = db.fund_Type.Where(x => x.Fund_TypeID == type);
                //var donation = don.Select(x => x.fund_descriptionID).SingleOrDefault();
                //var dons = db.donor.Where(u => u.Id == uu.ToString()).Select(s => s.fund_descriptionID).SingleOrDefault().Take(0);
                //var fundcId = db.fund_des.Where(x => x.fund_descriptionID == donation).FirstOrDefault();
                //var fcId = fundcId.fund_descriptionID;
                var fundes = Session["funddes"] as string;
                var fun = db.fund_des.Where(x=>x.fund_descriptionID == fundes);
                var funcat = Session["fundcat"] as string;
                var fundcat = db.fund_Categories.Where(y => y.Fund_CategoriesID == funcat);
                var dono = Session["donor"] as string;
                var fundonor = db.donor.Where(y => y.DonorID == dono);
                //var fundcat = db.fund_Categories.Where(y => y.Fund_CategoriesID == fcId);
                //var funtypeId = don.Select(x=>x.Fund_TypeID).FirstOrDefault();
                //var fundtype = db.fund_Type.Where(y => y.Fund_TypeID == funtypeId);
                //var fun_des = db.fund_des.Where(g => g.fund_descriptionID == dons).Select(y => y.Fund_CategoriesID).SingleOrDefault();
                //var ff = db.fund_Categories.Where(xx => xx.Fund_CategoriesID == fun_des);
                //var funtype = db.donor.Where(u => u.Id == uu.ToString()).Select(L => L.Fund_TypeID).SingleOrDefault();
                //var fund_type = db.fund_Type.Where(j => j.Fund_TypeID == funtype);

                obj = new ProfileViewModel
                {

                    P_Profile = pro.ToList(),
                    P_donor = fundonor.ToList(),
                    P_fund_Categories = fundcat.ToList(),
                    P_fund_Type = donate.ToList(),
                    P_registration_type = db.registration_type.ToList(),
                    P_fund_dess=fun.ToList(),
                    P_User = user.ToList(),
                    P_organization = org.ToList()

                };
                ViewBag.Get_details = obj;
                return obj;
            }
            return null;

        }
        private void data(IQueryable<ApplicationUser> user, IQueryable<Profile_biulding> pro, IQueryable<Donor> don)
        {
            ViewBag.User_data = user;
            ViewBag.Pro_Data = pro;
            ViewBag.don_Data = don;
        }



        public ActionResult ViewDonations()
        {

            var uu = Session["use"];
            var user = db.Users.Where(a => a.Id == uu.ToString());
            var balance = db.balanceDetails.Where(w => w.UserID == uu.ToString());
            return View(balance);

        }

        public ActionResult ViewRecieverRequests()
        {

            var uu = Session["use"];
            var user = db.Users.Where(w => w.Id == uu.ToString()).FirstOrDefault();
            List<RecieverReports> listItems = new List<RecieverReports>();
            var rec = db.receiver.Where(w => w.Id == uu.ToString()).ToList();
            foreach (var item in rec)
            {
                RecieverReports reportItem = new RecieverReports();

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

        public ActionResult AddDonations()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddDonations(DonorViewModel model)
        {
            var uu = Session["use"];
            if (uu.ToString() != "")
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
                string f_dec = "";
                f_dec = Guid.NewGuid().ToString();
                fund_description fd = new fund_description()
                {
                    fund_descriptionID = f_dec,
                    Fund_CategoriesID = fund,

                };
                String userid = uu.ToString();
                string donor = "";
                donor = Guid.NewGuid().ToString();
                Donor dd = new Donor()
                {
                    Id = userid,
                    DonorID = fund,
                    Fund_TypeID = new_id,
                    frequency = model.frequency,
                    Amount = model.Amount,
                    fund_descriptionID = f_dec,

                };
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


                db.fund_Type.Add(f_type);
                //db.SaveChanges();
                db.fund_Categories.Add(ff);
                //db.SaveChanges();
                db.fund_des.Add(fd);
                //db.SaveChanges();
                db.donor.Add(dd);
                //db.SaveChanges();
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
                else if ((model.Education == "Education") && (model.Health == "Health") && (model.Other == "Other"))
                {
                    balance.Others = (float)((50 / 100.0) * totalAfterDeduction);
                    balance.Health = 0;
                    balance.Education = (float)((50 / 100.0) * totalAfterDeduction);
                }
                else if ((model.Education == "Education") && (model.Health == "Health") && (model.Other == "Other"))
                {
                    balance.Others = (float)((50 / 100.0) * totalAfterDeduction);
                    balance.Health = (float)((50 / 100.0) * totalAfterDeduction);
                    balance.Education = 0;
                }
                else if ((model.Education == "Education") && (model.Health == "Health") && (model.Other == null))
                {
                    balance.Others = 0;
                    balance.Health = 0;
                    balance.Education = (float)totalAfterDeduction;
                }
                else if ((model.Education == "Education") && (model.Health == "Health") && (model.Other == null))
                {
                    balance.Others = 0;
                    balance.Health = (float)totalAfterDeduction;
                    balance.Education = 0;
                }
                else if ((model.Education == null) && (model.Health == null) && (model.Other == "Other"))
                {
                    balance.Others = (float)totalAfterDeduction;
                    balance.Health = 0;
                    balance.Education = 0;
                }

                balance.UserID = userid;
                balance.DonorID = fund;
                db.balanceDetails.Add(balance);
                //db.SaveChanges();
                db.SaveChanges();

                //db.account.Add(acc);
                //db.SaveChanges();
                return RedirectToAction("Userprofile", "Profile");
            }


            return View();
        }

        public ActionResult DonateDonatio()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DonateDonatio(DonorViewModel donorView)
        {

            String don = donorView.Health;


            return View();
        }







        public ActionResult Userprofile()
        {

            if (result() != null)
            {
                return View(result());
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Userprofile(ApplicationUser use, Profile_biulding pro, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    pro.picture = Path_Genarator(file);
                }
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
                ApplicationUser user = db.Users.Find(use.Id);
                user.FirstName = use.FirstName; user.Id = use.Id; user.LastName = use.LastName; user.Address = use.Address; user.Phone = use.Phone;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                Profile_biulding profil = db.Profile.Find(pro.Profile_biuldingID);
                db.Entry(profil).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Userprofile", "Profile");

            }


            return HttpNotFound();
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
            //Image i = System.Drawing.Image.FromFile(paths);
            //i.RotateFlip(RotateFlipType.Rotate90FlipXY);

        }
        public ActionResult Admin()
        {

            //if (result() != null)
            //{
            //    return View(result());
            //}
            //else
            //{
            //    return HttpNotFound();
            //}
            return View();
        }
        public ActionResult Receiver_update()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Receiver_update(Fund_sub_cat fsc, Fund_Categories fc, Receiver re)
        {
            if (ModelState.IsValid)
            {
                var use = User.Identity.GetUserId();
                Receiver rec = db.receiver.Where(d => d.Id == use).SingleOrDefault();
                if (rec != null)
                {
                    rec.amount = re.amount;
                    db.Entry(rec).State = EntityState.Modified;
                    db.SaveChanges();
                    fund_description fun_des = db.fund_des.Find(rec.fund_descriptionID);
                    db.Entry(fun_des).State = EntityState.Modified;
                    db.SaveChanges();
                    Fund_Categories fun_cat = db.fund_Categories.Find(fun_des.Fund_CategoriesID);
                    fun_cat.Education = fc.Education; fun_cat.Health = fc.Health; fun_cat.Loan = fc.Loan;
                    db.Entry(fun_cat).State = EntityState.Modified;
                    db.SaveChanges();
                    Fund_sub_cat fun_sub = db.fund_sub_cat.Find(fun_des.Fund_sub_catID);
                    fun_sub.AdmissionFee = fsc.AdmissionFee; fun_sub.Accessories = fsc.Accessories; fun_sub.Medicine = fsc.Medicine; fun_sub.Uniform = fsc.Uniform; fun_sub.Minor_Surgury = fsc.Minor_Surgury; fun_sub.Test_Reports = fsc.Test_Reports;
                    db.Entry(fun_cat).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                }

                return RedirectToAction("ReceiverIndividual", "Profile");

            }
            return HttpNotFound();
        }
        public ActionResult Donar_update()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Donar_update(Fund_Categories fc, Fund_Type ft, Donor dd)
        {
            if (ModelState.IsValid)
            {
                var use = User.Identity.GetUserId();
                //Donor don = db.donor.Where(d => d.Id == use).SingleOrDefault();
                //if (don != null)
                {
                    //Fund_Type fun = db.fund_Type.Find(don.Fund_TypeID);
                    string new_id = "";
                    new_id = Guid.NewGuid().ToString();
                    Fund_Type fund = new Fund_Type()
                    {
                    Atia_o_Khairat = ft.Atia_o_Khairat, Sadaqah = ft.Sadaqah,Fund_TypeID=new_id,
                    khums = ft.khums,Usher = ft.Usher,Zakat = ft.Zakat,zakat_ul_fitr = ft.zakat_ul_fitr

                };
                    Session["fund"] =fund.Fund_TypeID;
                    db.fund_Type.Add(fund);
                    db.SaveChanges();
                    string func = Guid.NewGuid().ToString();
                    Fund_Categories fundcat = new Fund_Categories()
                    {
                        Fund_CategoriesID=func,
                        Education = fc.Education,
                        Health = fc.Health,
                        Loan = fc.Loan
                    };
                    //Fund_Categories fun_cat = db.fund_Categories.Find(fun_des.Fund_CategoriesID);
                    Session["fundcat"] = fundcat.Fund_CategoriesID;
                    db.fund_Categories.Add(fundcat);
                    db.SaveChanges();
                   
                    string funn = Guid.NewGuid().ToString();
                    fund_description funddes = new fund_description()
                    {
                        fund_descriptionID = funn,
                        Fund_CategoriesID = func
                    };
                    Session["funddes"] = funddes.fund_descriptionID;
                    //fund_description fun_des = db.fund_des.Find(don.fund_descriptionID);
                    db.fund_des.Add(funddes);
                    db.SaveChanges();

                    string dono = Guid.NewGuid().ToString();
                    Donor doo = new Donor()
                    {
                        DonorID=dono,
                        Amount = dd.Amount,
                        Id=use,
                        Fund_TypeID= new_id,
                        fund_descriptionID=funn

                    };
                    Session["donor"] = doo.DonorID;
                    db.donor.Add(doo);
                    db.SaveChanges();
                  
                    ModelState.Clear();
                }

                return RedirectToAction("Userprofile", "Profile");

            }
            return HttpNotFound();
        }

        // GET: Profile
        public ActionResult ReceiverIndividual()
        {

            if (rec_result() != null)
            {
                return View(rec_result());
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReceiverIndividual(ApplicationUser use, Profile_biulding pro, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = db.Users.Find(use.Id);
                user.Id = use.Id; user.Address = use.Address; user.Phone = use.Phone; user.Selected_Area = use.Selected_Area; user.Selected_city = use.Selected_city;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                Profile_biulding profil = db.Profile.Find(pro.Profile_biuldingID);
                db.Entry(profil).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("ReceiverIndividual", "Profile");

            }
            return HttpNotFound();
        }

        public ActionResult Notifications()
        {
            return View();
        }
        public ActionResult Tables()
        {
            return View();
        }
        public ActionResult Volunteer()
        {
            if (result() != null)
            {
                return View(result());
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Volunteer(ApplicationUser use, Profile_biulding pro, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = db.Users.Find(use.Id);
                user.Id = use.Id; user.Address = use.Address; user.Phone = use.Phone;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                Profile_biulding profil = db.Profile.Find(pro.Profile_biuldingID);
                db.Entry(profil).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Userprofile", "Profile");

            }


            return HttpNotFound();
        }
        public ActionResult DonorOrganisation()
        {
            if (result() != null)
            {
                return View(result());
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DonorOrganisation(ApplicationUser use, Profile_biulding pro, Organization oo, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = db.Users.Find(use.Id);
                user.Id = use.Id; user.Address = use.Address; user.Phone = use.Phone;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                Organization org = db.organization.Where(d => d.Id == use.Id).SingleOrDefault();
                org.owner_Name = oo.owner_Name; org.owner_LastName = oo.owner_LastName; org.owner_Email = oo.owner_Email; org.owner_PhoneNum = oo.owner_PhoneNum; org.owner_Address = oo.owner_Address; org.owner_CNIC = oo.owner_CNIC;
                db.Entry(org).State = EntityState.Modified;
                db.SaveChanges();
                Profile_biulding profil = db.Profile.Find(pro.Profile_biuldingID);
                db.Entry(profil).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("DonorOrganisation", "Profile");

            }


            return HttpNotFound();
        }
        public ActionResult ReceiverOrganisation()
        {
            if (rec_result() != null)
            {
                return View(rec_result());
            }
            else
            {
                return HttpNotFound();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReceiverOrganisation(ApplicationUser use, Profile_biulding pro, HttpPostedFileBase file, Organization oo)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = db.Users.Find(use.Id);
                user.Id = use.Id; user.Address = use.Address; user.Phone = use.Phone; user.Selected_Area = use.Selected_Area; user.Selected_city = use.Selected_city;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                Organization org = db.organization.Where(d => d.Id == use.Id).SingleOrDefault();
                org.owner_Name = oo.owner_Name; org.owner_LastName = oo.owner_LastName; org.owner_Email = oo.owner_Email; org.owner_PhoneNum = oo.owner_PhoneNum; org.owner_Address = oo.owner_Address; org.owner_CNIC = oo.owner_CNIC;
                db.Entry(org).State = EntityState.Modified;
                db.SaveChanges();
                Profile_biulding profil = db.Profile.Find(pro.Profile_biuldingID);
                db.Entry(profil).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("ReceiverOrganisation", "Profile");

            }
            return HttpNotFound();
        }


        public ActionResult Donor()
        {
            var id = User.Identity.GetUserId();
            return View();
        }
        public ActionResult ReceiverProfile()
        {
            return View();
        }


        public ProfileViewModel rec_result()
        {
            var uu = User.Identity.GetUserId();
            if (uu != null)
            {
                var user = db.Users.Where(a => a.Id == uu.ToString());
                var pro = db.Profile.Where(w => w.Id == uu.ToString());
                var org = db.organization.Where(w => w.Id == uu.ToString());
                var rec = db.receiver.Where(u => u.Id == uu.ToString());
                var dons = db.receiver.Where(u => u.Id == uu.ToString()).Select(s => s.fund_descriptionID).SingleOrDefault();
                var fun_des = db.fund_des.Where(g => g.fund_descriptionID == dons).Select(y => y.Fund_CategoriesID).SingleOrDefault();
                var ff = db.fund_Categories.Where(xx => xx.Fund_CategoriesID == fun_des);
                var funtype = db.fund_des.Where(g => g.fund_descriptionID == dons).Select(y => y.Fund_sub_catID).SingleOrDefault();
                var f_sub = db.fund_sub_cat.Where(xx => xx.Fund_sub_catID == funtype);

                obj = new ProfileViewModel
                {

                    P_Profile = pro.ToList(),
                    P_receiver = rec.ToList(),
                    P_fund_Categories = ff.ToList(),
                    P_fund_sub_cat = f_sub.ToList(),
                    P_registration_type = db.registration_type.ToList(),
                    //P_role = db.role.ToList(),
                    P_User = user.ToList(),
                    P_organization = org.ToList()

                };
                ViewBag.Get_details = obj;
                return obj;
            }
            return null;

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult profile_picture(string Id, HttpPostedFileBase file)
        {
            if (Id != null)
            {
                var uu = User.Identity.GetUserId();
                var dons = db.Users.Where(u => u.Id == uu.ToString()).Select(m => m.Category).SingleOrDefault();
                var pp = db.Users.Where(u => u.Id == uu.ToString()).Select(n => n.in_org).SingleOrDefault();
                var s = db.Profile.Where(k => k.Id == Id).Select(j => j.Profile_biuldingID).SingleOrDefault();
                var pro = db.Profile.Find(s);
                if (file != null && file.ContentLength > 0)
                {
                    pro.picture = Path_Genarator(file);
                    pro.personal_info = Path_Genarator(file);
                }
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
                if (dons == ("Donor") && pp==("Individual"))
                {
                    return RedirectToAction("Userprofile", "Profile");
                }
                else if (dons == ("Receiver") && pp == ("Individual"))
                {
                    return RedirectToAction("ReceiverIndividual", "Profile");
                }
                else if (dons == ("Donor") && pp == ("Organization"))
                {
                    return RedirectToAction("DonorOrganisation", "Profile");
                }
                else if (dons == ("Receiver") && pp == ("Organization"))
                {
                    return RedirectToAction("ReceiverOrganisation", "Profile");
                }
                else if (dons==("Volunteer"))
                {
                    return RedirectToAction("Volunteer", "Profile");
                }
                return RedirectToAction("Userprofile");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult profile_volunteer(string Id, HttpPostedFileBase file)
        {
            if (Id != null)
            {
                var s = db.Profile.Where(k => k.Id == Id).Select(j => j.Profile_biuldingID).SingleOrDefault();
                var pro = db.Profile.Find(s);
                if (file != null && file.ContentLength > 0)
                {
                    pro.picture = Path_Genarator(file);
                }
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Volunteer", "Profile");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


    }

}