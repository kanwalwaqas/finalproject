using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ProfileViewModel obj;
        public HomeController ()
        {           
                obj = new ProfileViewModel
                {
                    banner=db.Dbbanner.ToList(),
                    P_Profile = db.Profile.ToList(),
                    work_event=db.work_event.ToList(),
                    work_sub=db.work_sub.ToList(),
                    P_fund_Categories = db.fund_Categories.ToList(),
                    P_fund_Type = db.fund_Type.ToList(),
                    P_team=db.team.ToList(),
                    P_registration_type = db.registration_type.ToList(),
                   
                    P_User = db.Users.ToList(),
                    P_organization = db.organization.ToList()

                };
                
            
         

        }

        public ActionResult Index()
        {
            return View(obj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Event(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_sub_cat ev = db.work_sub.Find(id);
            if (ev == null)
            {
                return HttpNotFound();
            }
            return View(ev);
        }
    }
}