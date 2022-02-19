using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCYips.Models;

namespace BCYips.Controllers
{
    public class YipsController : Controller
    {
        private YipDbContext db = new YipDbContext();

        //
        // POST: /Yips/Create

        [HttpPost]
        public ActionResult Create(Yip yip)
        {
            var yipper = db.Yippers.First(s => s.UserName == User.Identity.Name);
            yip.YipperID = yipper.ID;
            yip.Yipper = yipper;
            yip.Posted = DateTime.Now;
            ModelState.Remove("Yipper");
            var isValid = ModelState.IsValid && !string.IsNullOrWhiteSpace(yip.Content);

            if (isValid)
            {
                db.Yips.Add(yip);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ((System.Web.Mvc.ModelState)ModelState["Content"]).Errors.Add(new ModelError("There was an error posting your yip."));
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}