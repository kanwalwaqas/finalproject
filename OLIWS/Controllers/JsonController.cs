using OLIWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLIWS.Controllers
{
    public class JsonController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        public JsonResult CheckUsername(string username)
        {
            if (username == "")
            {
                return Json(2);
            }
            // System.Threading.Thread.Sleep(1);
            bool isValid = db.Users.ToList().Exists(p => p.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            return Json(isValid);
        }
        public JsonResult Check_Roles(string name)
        {
            // System.Threading.Thread.Sleep(50);
            if (name == "")
            {
                return Json(2);
            }
            bool check = db.Roles.ToList().Exists(p => p.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            return Json(check);
        }
    }
}