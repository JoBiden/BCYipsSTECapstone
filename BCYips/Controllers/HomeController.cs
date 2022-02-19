using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BCYips.Models;

namespace BCYips.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private YipDbContext db = new YipDbContext();

        public ActionResult Index()
        {
            ViewBag.Yips = db.Yips.ToList();
            ViewBag.Message = User.Identity.Name;
            var profile = db.Yippers.First(s => s.UserName == User.Identity.Name);
            ViewBag.Profile = profile;
            ViewBag.Yipper = profile;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Explore()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
    }
}
