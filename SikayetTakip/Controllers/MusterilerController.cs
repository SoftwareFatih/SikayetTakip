using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SikayetTakip.Data;
using SikayetTakip.Models;

namespace SikayetTakip.Controllers
{
    public class MusterilerController : Controller
    {
        private SikayetContext db = new SikayetContext();

        // GET: Musteriler
        public ActionResult Index()
        {
            return View(db.Musteriler.ToList());
        }

        // GET: Musteriler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteriler.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // GET: Musteriler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musteriler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdSoyad")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Musteriler.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteri);
        }

        // GET: Musteriler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteriler.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Musteriler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdSoyad")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        // GET: Musteriler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteriler.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Musteriler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteri musteri = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteri);
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
