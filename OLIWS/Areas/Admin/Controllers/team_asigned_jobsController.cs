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
    public class team_asigned_jobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/team_asigned_jobs
        public ActionResult Index()
        {
            var tm_job_assign = db.tm_job_assign.Include(t => t.team);
            return View(tm_job_assign.ToList());
        }

        // GET: Admin/team_asigned_jobs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            team_asigned_jobs team_asigned_jobs = db.tm_job_assign.Find(id);
            if (team_asigned_jobs == null)
            {
                return HttpNotFound();
            }
            return View(team_asigned_jobs);
        }

        // GET: Admin/team_asigned_jobs/Create
        public ActionResult Create()
        {
            var use = db.Roles.Where(s => s.Name == "Receiver").Select(k => k.Users.Select(o => o.UserId)).SingleOrDefault();
            if (use != null)
            {
                ViewBag.TeamID = new SelectList(db.team, "TeamID", "verify");
                return View();
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/team_asigned_jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tm_job_Id,Job_status,TeamID,currentdate")] team_asigned_jobs team_asigned_jobs)
        {
            if (ModelState.IsValid)
            {
                db.tm_job_assign.Add(team_asigned_jobs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.team, "TeamID", "verify", team_asigned_jobs.TeamID);
            return View(team_asigned_jobs);
        }
        // GET: Admin/team_asigned_jobs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            team_asigned_jobs team_asigned_jobs = db.tm_job_assign.Find(id);
            if (team_asigned_jobs == null)
            {
                return HttpNotFound();
            }
            return View(team_asigned_jobs);
        }

        // POST: Admin/team_asigned_jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            team_asigned_jobs team_asigned_jobs = db.tm_job_assign.Find(id);
            team_asigned_jobs.Job_status = 0;
            db.Entry(team_asigned_jobs).State = EntityState.Modified;
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
