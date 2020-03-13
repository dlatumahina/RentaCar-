using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentaCar.Models;

namespace RentaCar.Controllers
{
    public class AutoController : Controller
    {
        private RentaCarEntities db = new RentaCarEntities();

        // GET: Auto
        public ActionResult Index()
        {
            return View(db.auto.ToList());
        }

        // GET: Auto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.auto.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Auto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kenteken,merk,type,dagprijs,beschikbaar,foto")] auto auto)
        {
            if (ModelState.IsValid)
            {
                db.auto.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auto);
        }

        // GET: Auto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.auto.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Auto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kenteken,merk,type,dagprijs,beschikbaar,foto")] auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auto);
        }

        // GET: Auto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.auto.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            auto auto = db.auto.Find(id);
            db.auto.Remove(auto);
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
