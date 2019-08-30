using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using otoparkprojesi.DAL;

namespace otoparkprojesi.Controllers
{
    public class musterisController : Controller
    {
        private otoparkEntities db = new otoparkEntities();

        // GET: musteris
        public ActionResult Index()
        {
            var musteri = db.musteri.Include(m => m.AracTakip);
            return View(musteri.ToList());
        }

        // GET: musteris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            musteri musteri = db.musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // GET: musteris/Create
        public ActionResult Create()
        {
            ViewBag.AracID = new SelectList(db.AracTakip, "AracID", "AracID");
            return View();
        }

        // POST: musteris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusteriID,MusteriTc,MusteriAd,MusteriSoyad,MusteriTelefon,AracPlaka,AracMarka,Konumu,Tarih,AracUcret,AracID")] musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.musteri.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AracID = new SelectList(db.AracTakip, "AracID", "AracID", musteri.AracID);
            return View(musteri);
        }

        // GET: musteris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            musteri musteri = db.musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            ViewBag.AracID = new SelectList(db.AracTakip, "AracID", "AracID", musteri.AracID);
            return View(musteri);
        }

        // POST: musteris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusteriID,MusteriTc,MusteriAd,MusteriSoyad,MusteriTelefon,AracPlaka,AracMarka,Konumu,Tarih,AracUcret,AracID")] musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AracID = new SelectList(db.AracTakip, "AracID", "AracID", musteri.AracID);
            return View(musteri);
        }

        // GET: musteris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            musteri musteri = db.musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }

            return View(musteri);
        }

        // POST: musteris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            musteri musteri = db.musteri.Find(id);
            db.musteri.Remove(musteri);
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
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult İletisim()
        {
            return View();
        }
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult OtoparkSistem()
        {
            return View();
        }
        public ActionResult OtoparkYönetim()
        {
            return View();
        }

    }
}
