using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TEST.Models;

namespace TEST.Controllers
{
    public class DICHVUsController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();

        // GET: DICHVUs
        public ActionResult Index()
        {
            return View(db.DICHVUs.ToList());
        }
        [HttpPost]
        public ActionResult Index(String tenDV)
        {
            var dichVus = db.DICHVUs.Where(abc => abc.TENDV.Contains(tenDV));
            return View(dichVus.ToList());
        }

        // GET: DICHVUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DICHVU dICHVU = db.DICHVUs.Find(id);
            if (dICHVU == null)
            {
                return HttpNotFound();
            }
            return View(dICHVU);
        }

        // GET: DICHVUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DICHVUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADV,TENDV,DONGIADV")] DICHVU dICHVU)
        {
            if (ModelState.IsValid)
            {
                db.DICHVUs.Add(dICHVU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dICHVU);
        }

        // GET: DICHVUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DICHVU dICHVU = db.DICHVUs.Find(id);
            if (dICHVU == null)
            {
                return HttpNotFound();
            }
            return View(dICHVU);
        }

        // POST: DICHVUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADV,TENDV,DONGIADV")] DICHVU dICHVU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dICHVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dICHVU);
        }

        // GET: DICHVUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DICHVU dICHVU = db.DICHVUs.Find(id);
            if (dICHVU == null)
            {
                return HttpNotFound();
            }
            return View(dICHVU);
        }

        // POST: DICHVUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DICHVU dICHVU = db.DICHVUs.Find(id);
            db.DICHVUs.Remove(dICHVU);
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
