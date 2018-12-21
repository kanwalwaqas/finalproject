using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Areas.Admin.Controllers
{
    public class BannerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Banner
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Banner u, IEnumerable<HttpPostedFileBase> file)
        {

            foreach (HttpPostedFileBase item in file)
            {
                if (item != null && item.ContentLength > 0)

                {

                    u.Image = Path_Genarator(item);
                }
            }
                    string voll = "";
            voll = Guid.NewGuid().ToString();
            Banner vel = new Banner()
            {
                Banner_Id = voll,
                Name=u.Name,
                Image = u.Image,
                Description=u.Description,
                Id=u.Id
                


                
            };
            db.Dbbanner.Add(vel);
            db.SaveChanges();
            return View();
        }
        private string Path_Genarator(HttpPostedFileBase file)

        {
            var fileName = Path.GetFileName(file.FileName);
            var paths = Path.Combine(Server.MapPath("/Images/"), fileName);
            file.SaveAs(paths);
            //evidence_Submission_Detail.File = paths;                             
            string fl = paths.Substring(paths.LastIndexOf("\\"));
            string[] split = fl.Split('\\');
            string newpath = split[1];
            string imagepath = "~/Images/" + newpath;
            return imagepath;
            Image i = System.Drawing.Image.FromFile(paths);
            i.RotateFlip(RotateFlipType.Rotate90FlipXY);

        }
    }
}