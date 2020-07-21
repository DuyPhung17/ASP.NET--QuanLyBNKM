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
    public class CT_TOATHUOCController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();

        // GET: CT_TOATHUOC
        public ActionResult Index(int? id)
        {
            var cT_TOATHUOC = db.CT_TOATHUOC.Where(abc => abc.MATOATHUOC == id);
            int MABN = db.HSBAs.Find(id).MABN;
            ViewBag.TENBN = db.BENHNHANs.Find(MABN).TENBN;
            ViewBag.NGAYKE = db.TOATHUOCs.Find(id).NGAYKE.ToString("dd/MM/yyyy");
            return View(cT_TOATHUOC.ToList());
        }
        [HttpPost]
        public ActionResult Index(int? id,String thuoc)
        {
            var cT_TOATHUOC = db.CT_TOATHUOC.Where(abc => abc.THUOC.TENTHUOC.Contains(thuoc));
            int MABN = db.HSBAs.Find(id).MABN;
            ViewBag.TENBN = db.BENHNHANs.Find(MABN).TENBN;
            ViewBag.NGAYKE = db.TOATHUOCs.Find(id).NGAYKE.ToString("dd/MM/yyyy");
            return View(cT_TOATHUOC.ToList());
        }

        // GET: CT_TOATHUOC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_TOATHUOC cT_TOATHUOC = db.CT_TOATHUOC.Find(id);
            if (cT_TOATHUOC == null)
            {
                return HttpNotFound();
            }
            return View(cT_TOATHUOC);
        }

        // GET: CT_TOATHUOC/Create
        public ActionResult Create()
        {
            ViewBag.MATHUOC = new SelectList(db.THUOCs, "MATHUOC", "TENTHUOC");
            ViewBag.MATOATHUOC = new SelectList(db.TOATHUOCs, "MATOATHUOC", "MATOATHUOC");
            return View();
        }

        // POST: CT_TOATHUOC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATOATHUOC,MATHUOC,SOLUONG,LIEUDUNG")] CT_TOATHUOC cT_TOATHUOC)
        {
            if (ModelState.IsValid)
            {
                db.CT_TOATHUOC.Add(cT_TOATHUOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATHUOC = new SelectList(db.THUOCs, "MATHUOC", "TENTHUOC", cT_TOATHUOC.MATHUOC);
            ViewBag.MATOATHUOC = new SelectList(db.TOATHUOCs, "MATOATHUOC", "MATOATHUOC", cT_TOATHUOC.MATOATHUOC);
            return View(cT_TOATHUOC);
        }

        // GET: CT_TOATHUOC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_TOATHUOC cT_TOATHUOC = db.CT_TOATHUOC.Find(id);
            if (cT_TOATHUOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATHUOC = new SelectList(db.THUOCs, "MATHUOC", "TENTHUOC", cT_TOATHUOC.MATHUOC);
            ViewBag.MATOATHUOC = new SelectList(db.TOATHUOCs, "MATOATHUOC", "MATOATHUOC", cT_TOATHUOC.MATOATHUOC);
            return View(cT_TOATHUOC);
        }

        // POST: CT_TOATHUOC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATOATHUOC,MATHUOC,SOLUONG,LIEUDUNG")] CT_TOATHUOC cT_TOATHUOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_TOATHUOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATHUOC = new SelectList(db.THUOCs, "MATHUOC", "TENTHUOC", cT_TOATHUOC.MATHUOC);
            ViewBag.MATOATHUOC = new SelectList(db.TOATHUOCs, "MATOATHUOC", "MATOATHUOC", cT_TOATHUOC.MATOATHUOC);
            return View(cT_TOATHUOC);
        }

        // GET: CT_TOATHUOC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_TOATHUOC cT_TOATHUOC = db.CT_TOATHUOC.Find(id);
            if (cT_TOATHUOC == null)
            {
                return HttpNotFound();
            }
            return View(cT_TOATHUOC);
        }

        // POST: CT_TOATHUOC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_TOATHUOC cT_TOATHUOC = db.CT_TOATHUOC.Find(id);
            db.CT_TOATHUOC.Remove(cT_TOATHUOC);
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
