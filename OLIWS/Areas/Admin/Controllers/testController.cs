using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Areas.Admin.Controllers
{
    public class testController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Country()
        {
            var chk = db.Countries.ToList();
            if (chk != null)
            {
                return View(chk);
            }
            
                
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult country(Country con)
        {
            var chk = db.Countries.ToList();
            foreach (var item in chk)
            {
                if (item.country_name.Contains(con.country_name))
                {
                    ViewBag.CountryError = "Country already Exist";
                    return View(chk);
                }
                if (ModelState.IsValid)
                {
                    var id = Guid.NewGuid();
                    con.CountryID = id.ToString();
                    db.Countries.Add(con);
                    db.SaveChanges();
                    return RedirectToAction("Country", "test");
                }

               
            }
            return View(chk);
        }

    }
}