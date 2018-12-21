using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OLIWS.Models;

namespace OLIWS.Areas.Admin.Controllers
{
    public class CampaignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Campaigns
        public ActionResult Index()
        {
            return View(db.campaigns.ToList());
        }

        // GET: Admin/Campaigns/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaigns campaigns = db.campaigns.Find(id);
            if (campaigns == null)
            {
                return HttpNotFound();
            }
            return View(campaigns);
        }

        // GET: Admin/Campaigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampaignsID,volunteer1,volunteer2,volunteer3,volunteer4,volunteer5,volunteer6,volunteer7,volunteer8,volunteer9,volunteer10,task,compaign_area,Purpose,date_time,timelimit,status")] Campaigns campaigns)
        {
            if (ModelState.IsValid)
            {
                db.campaigns.Add(campaigns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campaigns);
        }

        // GET: Admin/Campaigns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaigns campaigns = db.campaigns.Find(id);
            if (campaigns == null)
            {
                return HttpNotFound();
            }
            return View(campaigns);
        }

        // POST: Admin/Campaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampaignsID,volunteer1,volunteer2,volunteer3,volunteer4,volunteer5,volunteer6,volunteer7,volunteer8,volunteer9,volunteer10,task,compaign_area,Purpose,date_time,timelimit,status")] Campaigns campaigns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campaigns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campaigns);
        }

        // GET: Admin/Campaigns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaigns campaigns = db.campaigns.Find(id);
            if (campaigns == null)
            {
                return HttpNotFound();
            }
            return View(campaigns);
        }

        // POST: Admin/Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Campaigns campaigns = db.campaigns.Find(id);
            db.campaigns.Remove(campaigns);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
