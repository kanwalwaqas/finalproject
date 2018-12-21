using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Areas.Admin.Controllers
{
    public class LocalAreaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/LocalArea
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
    }
}