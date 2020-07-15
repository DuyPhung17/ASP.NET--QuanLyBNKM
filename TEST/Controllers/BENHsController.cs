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
    public class BENHsController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();

        // GET: BENHs
        public ActionResult Index()
        {
            return View(db.BENHs.ToList());
        }
        [HttpPost]
        public ActionResult Index(String tenBenh)
        {
            var benhs = db.BENHs.Where(abc => abc.TENBENH.Contains(tenBenh));
            return View(benhs.ToList());
        }

        // GET: BENHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENH bENH = db.BENHs.Find(id);
            if (bENH == null)
            {
                return HttpNotFound();
            }
            return View(bENH);
        }

        // GET: BENHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BENHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MABENH,TENBENH")] BENH bENH)
        {
            if (ModelState.IsValid)
            {
                db.BENHs.Add(bENH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bENH);
        }

        // GET: BENHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENH bENH = db.BENHs.Find(id);
            if (bENH == null)
            {
                return HttpNotFound();
            }
            return View(bENH);
        }

        // POST: BENHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MABENH,TENBENH")] BENH bENH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bENH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bENH);
        }

        // GET: BENHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENH bENH = db.BENHs.Find(id);
            if (bENH == null)
            {
                return HttpNotFound();
            }
            return View(bENH);
        }

        // POST: BENHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BENH bENH = db.BENHs.Find(id);
            db.BENHs.Remove(bENH);
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
