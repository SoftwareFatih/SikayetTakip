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
    public class SikayetlerController : Controller
    {
        private SikayetContext db = new SikayetContext();

        // GET: Sikayetler
        public ActionResult Index()
        {
            var sikayetler = db.Sikayetler.Include(s => s.Musteri);
            return View(sikayetler.ToList());
        }

        // GET: Sikayetler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sikayet sikayet = db.Sikayetler.Find(id);
            if (sikayet == null)
            {
                return HttpNotFound();
            }
            return View(sikayet);
        }

        // GET: Sikayetler/Create
        public ActionResult Create()
        {
            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "AdSoyad");
            return View();
        }

        // POST: Sikayetler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Baslik,Detay,KayitTarih,MusteriId")] Sikayet sikayet)
        {
            if (ModelState.IsValid)
            {
                db.Sikayetler.Add(sikayet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "AdSoyad", sikayet.MusteriId);
            return View(sikayet);
        }

        // GET: Sikayetler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sikayet sikayet = db.Sikayetler.Find(id);
            if (sikayet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "AdSoyad", sikayet.MusteriId);
            return View(sikayet);
        }

        // POST: Sikayetler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Detay,KayitTarih,MusteriId")] Sikayet sikayet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sikayet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "AdSoyad", sikayet.MusteriId);
            return View(sikayet);
        }

        // GET: Sikayetler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sikayet sikayet = db.Sikayetler.Find(id);
            if (sikayet == null)
            {
                return HttpNotFound();
            }
            return View(sikayet);
        }

        // POST: Sikayetler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sikayet sikayet = db.Sikayetler.Find(id);
            db.Sikayetler.Remove(sikayet);
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
