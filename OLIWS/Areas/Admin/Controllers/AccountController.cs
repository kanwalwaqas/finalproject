using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Account
        public ActionResult register()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult login([Bind(Include = "Id,FirstName,LastName,phone,Gender,Date_of_birth,CNIC,Religion,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.ApplicationUsers.Add(applicationUser);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }

        //            return View(applicationUser);
        //        }
        //    }
        //
    }
}