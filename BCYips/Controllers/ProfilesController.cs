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
    public class ProfilesController : Controller
    {
        private YipDbContext db = new YipDbContext();

        //
        // GET: /Profiles/

        public ActionResult Index(string username = "")
        {
            return View(db.Yippers.ToList());
        }

        //
        // GET: /Profiles/Details/5

        public ActionResult Details(int id = 0)
        {
            Yipper profile = db.Yippers.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // GET: /Profiles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Profiles/Create

        [HttpPost]
        public ActionResult Create(Yipper profile)
        {
            if (ModelState.IsValid)
            {
                db.Yippers.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        //
        // GET: /Profiles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Yipper profile = db.Yippers.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profiles/Edit/5

        [HttpPost]
        public ActionResult Edit(Yipper profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        //
        // GET: /Profiles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Yipper profile = db.Yippers.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profiles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Yipper profile = db.Yippers.Find(id);
            db.Yippers.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}