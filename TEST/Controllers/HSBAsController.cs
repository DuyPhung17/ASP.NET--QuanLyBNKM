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
    public class HSBAsController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();

        // GET: HSBAs
        public ActionResult Index()
        {
            var hSBAs = db.HSBAs.Include(h => h.BENH).Include(h => h.BENHNHAN);
            return View(hSBAs.ToList());
        }

        // GET: HSBAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HSBA hSBA = db.HSBAs.Find(id);
            if (hSBA == null)
            {
                return HttpNotFound();
            }
            return View(hSBA);
        }

        // GET: HSBAs/Create
        public ActionResult Create()
        {
            ViewBag.MABENH = new SelectList(db.BENHs, "MABENH", "TENBENH");
            ViewBag.MABN = new SelectList(db.BENHNHANs, "MABN", "TENBN");
            return View();
        }

        // POST: HSBAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHSBA,MABN,MABENH,NGAYNHAPVIEN")] HSBA hSBA)
        {
            if (ModelState.IsValid)
            {
                db.HSBAs.Add(hSBA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MABENH = new SelectList(db.BENHs, "MABENH", "TENBENH", hSBA.MABENH);
            ViewBag.MABN = new SelectList(db.BENHNHANs, "MABN", "TENBN", hSBA.MABN);
            return View(hSBA);
        }

        // GET: HSBAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HSBA hSBA = db.HSBAs.Find(id);
            if (hSBA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MABENH = new SelectList(db.BENHs, "MABENH", "TENBENH", hSBA.MABENH);
            ViewBag.MABN = new SelectList(db.BENHNHANs, "MABN", "TENBN", hSBA.MABN);
            return View(hSBA);
        }

        // POST: HSBAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHSBA,MABN,MABENH,NGAYNHAPVIEN")] HSBA hSBA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hSBA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MABENH = new SelectList(db.BENHs, "MABENH", "TENBENH", hSBA.MABENH);
            ViewBag.MABN = new SelectList(db.BENHNHANs, "MABN", "TENBN", hSBA.MABN);
            return View(hSBA);
        }

        // GET: HSBAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HSBA hSBA = db.HSBAs.Find(id);
            if (hSBA == null)
            {
                return HttpNotFound();
            }
            return View(hSBA);
        }

        // POST: HSBAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HSBA hSBA = db.HSBAs.Find(id);
            db.HSBAs.Remove(hSBA);
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
