using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Areas.Admin.Controllers
{
    public class LocalizedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Localized
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
            }
                if (ModelState.IsValid)
                {
                    db.Countries.Add(con);
                    db.SaveChanges();
                    return RedirectToAction("Country", "Localized");
                }


            
            return View(chk);
        }
        public ActionResult State(string stID)
        {
            if (stID != null)
            {
                Session["getId"] = stID;
             // string s=  Session["getId"] as string;
                List<State> _States = db.States.Where(st=> st.country_name == stID).ToList();
                return View(_States);
            }
            else
            {
                return RedirectToAction("State", "localized");
            }
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult State(State ss)
        {
            string v = Session["getId"] as string;
            
            var sta = db.States.Where(c => c.country_name == v).ToList();
            foreach (var item in sta)
            {
                if (item.state_name.Contains(ss.state_name))
                {
                    ViewBag.CountryExistencesError = "state already exist";
                    return View(sta);
                }
            }
                if (ModelState.IsValid)
                {
                    ss.country_name = v;
                    db.States.Add(ss);
                    db.SaveChanges();

                }
                return RedirectToAction("State", "localized");
       
      
        }
        public ActionResult city(string CID)
        {
            if (CID != null)
            {
                Session["shsh"] = CID;
                // string s=  Session["getId"] as string;
                List<City> ci = db.Cities.Where(s => s.state_name == CID).ToList();
                return View(ci);
            }
            else
            {
                return RedirectToAction("city", "localized");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult city(City cc)
        {
            string a = Session["shsh"] as string;

            var sta = db.Cities.Where(c => c.state_name == a).ToList();
            foreach (var item in sta)

                if (item.city_name.Contains(cc.city_name))
                {
                    ViewBag.CountryExistencesError = "city already exist";
                    return View(sta);
                }

            if (ModelState.IsValid)
            {
                cc.state_name = a;
                db.Cities.Add(cc);
                db.SaveChanges();

            }
            return RedirectToAction("city", "localized");

        }
    }
}