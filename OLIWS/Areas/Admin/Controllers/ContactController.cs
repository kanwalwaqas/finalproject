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
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Contact
        public ActionResult Index()
        {
            if (db.contact_us.ToList().Count() == 0)
            {
                ViewBag.emailcount = "";
            }
            else
            {
                ViewBag.emailcount = "(" + db.contact_us.Where(d => d.delete == false).Count() + ")";
            }
            if (db.contact_us.Where(s => s.Seen == true).ToList().Count() == 0)
            {
                ViewBag.emailseen = "";
            }
            else
            {
                ViewBag.emailseen = "(" + db.contact_us.Where(s => s.Seen == true).ToList().Count() + ")";
            }
            if (db.contact_us.Where(a => a.reply == true).ToList().Count() == 0)
            {
                ViewBag.emailsent = "";
            }
            else
            {
                ViewBag.emailsent = "(" + db.contact_us.Where(a => a.reply == true).ToList().Count() + ")";
            }
            if (db.contact_us.Where(a => a.delete == true).ToList().Count() == 0)
            {
                ViewBag.emaildeleted = "";
            }
            else
            {
                ViewBag.emaildeleted = "(" + db.contact_us.Where(a => a.delete == true).ToList().Count() + ")";
            }


            return View(db.contact_us.Where(o => o.delete == false).ToList());
        }
        public ActionResult show()
        {
            return View(db.contact_us.Where(s => s.delete == false).ToList());
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_us contact = db.contact_us.Find(id);
            if (contact.Seen == false)
            {
                contact.Seen = true;
                contact.Seen_By = User.Identity.Name;
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
            }
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }


        public ActionResult Create(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_us contact = db.contact_us.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        // GET: Admin/Contacts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_us contact = db.contact_us.Find(id);

            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Admin/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Contact_us contact = db.contact_us.Find(id);
            contact.delete = true;
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact_us cont, string s)
        {
            string contact = "";
            if (ModelState.IsValid)
            {
                contact = Guid.NewGuid().ToString();
                Contact_us con = new Contact_us()
                {
                    Contact_usID = contact,


                    con_Email = cont.con_Email,
                    subject = cont.subject

                };

                db.contact_us.Add(con);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    
        public ActionResult Compose(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser ap = db.Users.Find(id);
            if (ap == null)
            {
                return HttpNotFound();
            }
            return View(ap);
        }

    }
}