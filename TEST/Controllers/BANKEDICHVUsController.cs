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
    public class BANKEDICHVUsController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();

        // GET: BANKEDICHVUs
        public ActionResult Index(int? id)
        {
            var bANKEDICHVUs = db.BANKEDICHVUs.Where(abc => abc.MAHSBA == id);
            int MABN = db.HSBAs.Find(id).MABN;
            ViewBag.TENBN = db.BENHNHANs.Find(MABN).TENBN;
            return View(bANKEDICHVUs.ToList());
        }

        // GET: BANKEDICHVUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANKEDICHVU bANKEDICHVU = db.BANKEDICHVUs.Find(id);
            if (bANKEDICHVU == null)
            {
                return HttpNotFound();
            }
            return View(bANKEDICHVU);
        }

        // GET: BANKEDICHVUs/Create
        public ActionResult Create()
        {
            ViewBag.MAHSBA = new SelectList(db.HSBAs, "MAHSBA", "MAHSBA");
            return View();
        }

        // POST: BANKEDICHVUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MABKDV,MAHSBA,NGAYSUDUNG")] BANKEDICHVU bANKEDICHVU)
        {
            if (ModelState.IsValid)
            {
                db.BANKEDICHVUs.Add(bANKEDICHVU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHSBA = new SelectList(db.HSBAs, "MAHSBA", "MAHSBA", bANKEDICHVU.MAHSBA);
            return View(bANKEDICHVU);
        }

        // GET: BANKEDICHVUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANKEDICHVU bANKEDICHVU = db.BANKEDICHVUs.Find(id);
            if (bANKEDICHVU == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHSBA = new SelectList(db.HSBAs, "MAHSBA", "MAHSBA", bANKEDICHVU.MAHSBA);
            return View(bANKEDICHVU);
        }

        // POST: BANKEDICHVUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MABKDV,MAHSBA,NGAYSUDUNG")] BANKEDICHVU bANKEDICHVU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANKEDICHVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHSBA = new SelectList(db.HSBAs, "MAHSBA", "MAHSBA", bANKEDICHVU.MAHSBA);
            return View(bANKEDICHVU);
        }

        // GET: BANKEDICHVUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANKEDICHVU bANKEDICHVU = db.BANKEDICHVUs.Find(id);
            if (bANKEDICHVU == null)
            {
                return HttpNotFound();
            }
            return View(bANKEDICHVU);
        }

        // POST: BANKEDICHVUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANKEDICHVU bANKEDICHVU = db.BANKEDICHVUs.Find(id);
            db.BANKEDICHVUs.Remove(bANKEDICHVU);
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
