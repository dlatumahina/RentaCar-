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
    public class FactuurRegelController : Controller
    {
        private RentaCarEntities db = new RentaCarEntities();

        // GET: FactuurRegel
        public ActionResult Index()
        {
            var factuurregel = db.factuurregel.Include(f => f.auto).Include(f => f.factuur);
            return View(factuurregel.ToList());
        }

        // GET: FactuurRegel/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factuurregel factuurregel = db.factuurregel.Find(id);
            if (factuurregel == null)
            {
                return HttpNotFound();
            }
            return View(factuurregel);
        }

        // GET: FactuurRegel/Create
        public ActionResult Create()
        {
            ViewBag.kenteken = new SelectList(db.auto, "kenteken", "merk");
            ViewBag.factuurnummer = new SelectList(db.factuur, "factuurnummer", "klantcode");
            return View();
        }

        // POST: FactuurRegel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "factuurnummer,kenteken,begindatum,einddatum,dagprijs,totaal")] factuurregel factuurregel)
        {
            if (ModelState.IsValid)
            {
                db.factuurregel.Add(factuurregel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kenteken = new SelectList(db.auto, "kenteken", "merk", factuurregel.kenteken);
            ViewBag.factuurnummer = new SelectList(db.factuur, "factuurnummer", "klantcode", factuurregel.factuurnummer);
            return View(factuurregel);
        }

        // GET: FactuurRegel/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factuurregel factuurregel = db.factuurregel.Find(id);
            if (factuurregel == null)
            {
                return HttpNotFound();
            }
            ViewBag.kenteken = new SelectList(db.auto, "kenteken", "merk", factuurregel.kenteken);
            ViewBag.factuurnummer = new SelectList(db.factuur, "factuurnummer", "klantcode", factuurregel.factuurnummer);
            return View(factuurregel);
        }

        // POST: FactuurRegel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "factuurnummer,kenteken,begindatum,einddatum,dagprijs,totaal")] factuurregel factuurregel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factuurregel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kenteken = new SelectList(db.auto, "kenteken", "merk", factuurregel.kenteken);
            ViewBag.factuurnummer = new SelectList(db.factuur, "factuurnummer", "klantcode", factuurregel.factuurnummer);
            return View(factuurregel);
        }

        // GET: FactuurRegel/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factuurregel factuurregel = db.factuurregel.Find(id);
            if (factuurregel == null)
            {
                return HttpNotFound();
            }
            return View(factuurregel);
        }

        // POST: FactuurRegel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            factuurregel factuurregel = db.factuurregel.Find(id);
            db.factuurregel.Remove(factuurregel);
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
