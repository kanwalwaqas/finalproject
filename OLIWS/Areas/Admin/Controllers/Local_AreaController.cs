using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Areas.Admin.Controllers
{
    public class Local_AreaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Local_Area
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
            {
                string rec = "";
                rec = Guid.NewGuid().ToString();
                Country dd = new Country()
                {
                    CountryID = rec,
                    country_name = con.country_name,
                    status = con.status
                };
                db.Countries.Add(dd);
                db.SaveChanges();
                return RedirectToAction("Country", "Local_Area");
            }
           
        }
        public ActionResult con_edit(string id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country rol = db.Countries.Find(id);
            if (rol.Equals(null))
            {
                return HttpNotFound();
            }
            return View(rol);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult con_edit(Country pro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Country", "Local_Area");
            }
            return View(pro);
        }
        public ActionResult con_active(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country coun = db.Countries.Find(id);
            if (coun == null)
            {
                return HttpNotFound();
            }
            return View(coun);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult con_active(Country count)
        {
            if (ModelState.IsValid)
            {
                db.Entry(count).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Country", "Local_Area");
            }
            return View(count);
        }
        public ActionResult state(string stid)
        {
            if (stid != null)
            {
                Session["getId"] = stid;
                string s = Session["getId"] as string;
                List<State> sta = db.States.Where(st => st.CountryID == stid).ToList();
                return View(sta);
            }
            else
            {
                return RedirectToAction("Country", "Local_Area");
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult state(State ss)
        {
            string v = Session["getId"] as string;

            var sta = db.States.Where(c => c.CountryID == v).ToList();
            foreach (var item in sta)
            {
                if (item.state_name.Contains(ss.state_name))
                {
                    ViewBag.CountryExistencesError = "state already exist";
                    return View();
                }
            }
            if (ModelState.IsValid)
            {
                string rec = "";
                rec = Guid.NewGuid().ToString();
                State dd = new State()
                {
                    StateID = rec,
                    CountryID=v,
                    state_name = ss.state_name,
                    status = ss.status
                };
                db.States.Add(dd);
                db.SaveChanges();
                return RedirectToAction("Country", "Local_Area");
            }
            return RedirectToAction("state", "Local_Area");
        }
        public ActionResult sta_edit(string id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State rol = db.States.Find(id);
            if (rol.Equals(null))
            {
                return HttpNotFound();
            }
            return View(rol);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult sta_edit(State pro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Country", "Local_Area");
            }
            return View(pro);
        }

        public ActionResult sta_active(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State coun = db.States.Find(id);
            if (coun == null)
            {
                return HttpNotFound();
            }
            return View(coun);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult sta_active(State count)
        {
            if (ModelState.IsValid)
            {
                db.Entry(count).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Country", "Local_Area");
            }
            return View(count);
        }
        public ActionResult city(string cid)
        {
            if (cid != null)
            {
                Session["getId"] = cid;
                string s = Session["getId"] as string;
                List<City> sta = db.Cities.Where(st => st.StateID == cid).ToList();
                return View(sta);
            }
            else
            {
                return RedirectToAction("Country", "Local_Area");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult city(City cc)
        {
            string vv = Session["getId"] as string;

            var sta = db.Cities.Where(c => c.StateID == vv).ToList();
            foreach (var item in sta)
            {
                if (item.city_name.Contains(cc.city_name))
                {
                    ViewBag.CountryExistencesError = "state already exist";
                    return View();
                }
            }
            if (ModelState.IsValid)
            {
                string rec = "";
                rec = Guid.NewGuid().ToString();
                City dd = new City()
                {
                    CityID = rec,
                    StateID = vv,
                    city_name = cc.city_name,
                    status = cc.status
                };
                db.Cities.Add(dd);
                db.SaveChanges();
                return RedirectToAction("Country", "Local_Area");
            }
            return RedirectToAction("state", "Local_Area");
        }
        public ActionResult ci_edit(string id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City rol = db.Cities.Find(id);
            if (rol.Equals(null))
            {
                return HttpNotFound();
            }
            return View(rol);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ci_edit(City pro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Country", "Local_Area");
            }
            return View(pro);
        }
        public ActionResult citi_active(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City coun = db.Cities.Find(id);
            if (coun == null)
            {
                return HttpNotFound();
            }
            return View(coun);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult citi_active(City count)
        {
            if (ModelState.IsValid)
            {
                db.Entry(count).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Country", "Local_Area");
            }
            return View(count);
        }


    }
}