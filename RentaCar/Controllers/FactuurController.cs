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
    public class FactuurController : Controller
    {
        private RentaCarEntities db = new RentaCarEntities();

        // GET: Factuur
        public ActionResult Index()
        {
            var factuur = db.factuur.Include(f => f.klant).Include(f => f.medewerker);
            return View(factuur.ToList());
        }

        // GET: Factuur/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factuur factuur = db.factuur.Find(id);
            if (factuur == null)
            {
                return HttpNotFound();
            }
            return View(factuur);
        }

        // GET: Factuur/Create
        public ActionResult Create()
        {
            ViewBag.klantcode = new SelectList(db.klant, "klantcode", "voorletters");
            ViewBag.medewerkerscode = new SelectList(db.medewerker, "medewerkerscode", "voorletters");
            return View();
        }

        // POST: Factuur/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "factuurnummer,klantcode,medewerkerscode,datum,factuurtotaal")] factuur factuur)
        {
            if (ModelState.IsValid)
            {
                db.factuur.Add(factuur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.klantcode = new SelectList(db.klant, "klantcode", "voorletters", factuur.klantcode);
            ViewBag.medewerkerscode = new SelectList(db.medewerker, "medewerkerscode", "voorletters", factuur.medewerkerscode);
            return View(factuur);
        }

        // GET: Factuur/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factuur factuur = db.factuur.Find(id);
            if (factuur == null)
            {
                return HttpNotFound();
            }
            ViewBag.klantcode = new SelectList(db.klant, "klantcode", "voorletters", factuur.klantcode);
            ViewBag.medewerkerscode = new SelectList(db.medewerker, "medewerkerscode", "voorletters", factuur.medewerkerscode);
            return View(factuur);
        }

        // POST: Factuur/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "factuurnummer,klantcode,medewerkerscode,datum,factuurtotaal")] factuur factuur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factuur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klantcode = new SelectList(db.klant, "klantcode", "voorletters", factuur.klantcode);
            ViewBag.medewerkerscode = new SelectList(db.medewerker, "medewerkerscode", "voorletters", factuur.medewerkerscode);
            return View(factuur);
        }

        // GET: Factuur/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factuur factuur = db.factuur.Find(id);
            if (factuur == null)
            {
                return HttpNotFound();
            }
            return View(factuur);
        }

        // POST: Factuur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            factuur factuur = db.factuur.Find(id);
            db.factuur.Remove(factuur);
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
