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
    public class TOATHUOCsController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();

        // GET: TOATHUOCs
        public ActionResult Index(int? id)
        {
            var tOATHUOCs = db.TOATHUOCs.Where(abc => abc.MAHSBA == id);
            int MABN = db.HSBAs.Find(id).MABN;
            ViewBag.TENBN = db.BENHNHANs.Find(MABN).TENBN;
            return View(tOATHUOCs.ToList());
        }

        // GET: TOATHUOCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOATHUOC tOATHUOC = db.TOATHUOCs.Find(id);
            if (tOATHUOC == null)
            {
                return HttpNotFound();
            }
            return View(tOATHUOC);
        }

        // GET: TOATHUOCs/Create
        public ActionResult Create()
        {
            ViewBag.MAHSBA = new SelectList(db.HSBAs, "MAHSBA", "MAHSBA");
            return View();
        }

        // POST: TOATHUOCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATOATHUOC,MAHSBA,NGAYKE")] TOATHUOC tOATHUOC)
        {
            if (ModelState.IsValid)
            {
                db.TOATHUOCs.Add(tOATHUOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHSBA = new SelectList(db.HSBAs, "MAHSBA", "MAHSBA", tOATHUOC.MAHSBA);
            return View(tOATHUOC);
        }

        // GET: TOATHUOCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOATHUOC tOATHUOC = db.TOATHUOCs.Find(id);
            if (tOATHUOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHSBA = new SelectList(db.HSBAs, "MAHSBA", "MAHSBA", tOATHUOC.MAHSBA);
            return View(tOATHUOC);
        }

        // POST: TOATHUOCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATOATHUOC,MAHSBA,NGAYKE")] TOATHUOC tOATHUOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOATHUOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHSBA = new SelectList(db.HSBAs, "MAHSBA", "MAHSBA", tOATHUOC.MAHSBA);
            return View(tOATHUOC);
        }

        // GET: TOATHUOCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOATHUOC tOATHUOC = db.TOATHUOCs.Find(id);
            if (tOATHUOC == null)
            {
                return HttpNotFound();
            }
            return View(tOATHUOC);
        }

        // POST: TOATHUOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TOATHUOC tOATHUOC = db.TOATHUOCs.Find(id);
            db.TOATHUOCs.Remove(tOATHUOC);
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
