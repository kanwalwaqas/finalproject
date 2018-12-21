using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OLIWS.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OLIWS.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Admin/Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.role.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Admin/Roles/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] IdentityRole roles) {
            var tempRole = db.Roles.ToList();
            foreach(var item in tempRole)
            {
                if (item.Name.Contains(roles.Name))
                {
                    ViewBag.RoleExistenseError = "Role already Exist";
                    return View(tempRole);
                }
            }
        {
                db.Roles.Add(roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Roles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole rol = db.Roles.Find(id);
            if (rol.Equals(null))
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        // GET: Admin/Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole rol = db.Roles.Find(id);
            if (rol.Equals(null))
            {
                return HttpNotFound();
            }
            return View(rol);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletion(string id)
        {
            IdentityRole role = db.Roles.Find(id);
            if (role.Equals(null))
            {
                return HttpNotFound();
            }
            db.Roles.Remove(role);
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
