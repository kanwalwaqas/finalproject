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
    public class Fund_CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Fund_Categories
        public ActionResult Index()
        {
            return View(db.fundcategories.ToList());
        }

        // GET: Admin/Fund_Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fund_Categories fund_Categories = db.fundcategories.Find(id);
            if (fund_Categories == null)
            {
                return HttpNotFound();
            }
            return View(fund_Categories);
        }

        // GET: Admin/Fund_Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Fund_Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fund_CategoriesID,Education,Health,Loan,TakenTo")] Fund_Categories fund_Categories)
        {
            if (ModelState.IsValid)
            {
                db.fundcategories.Add(fund_Categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fund_Categories);
        }

        // GET: Admin/Fund_Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fund_Categories fund_Categories = db.fundcategories.Find(id);
            if (fund_Categories == null)
            {
                return HttpNotFound();
            }
            return View(fund_Categories);
        }

        // POST: Admin/Fund_Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fund_CategoriesID,Education,Health,Loan,TakenTo")] Fund_Categories fund_Categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fund_Categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fund_Categories);
        }

        // GET: Admin/Fund_Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fund_Categories fund_Categories = db.fundcategories.Find(id);
            if (fund_Categories == null)
            {
                return HttpNotFound();
            }
            return View(fund_Categories);
        }

        // POST: Admin/Fund_Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fund_Categories fund_Categories = db.fundcategories.Find(id);
            db.fundcategories.Remove(fund_Categories);
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
