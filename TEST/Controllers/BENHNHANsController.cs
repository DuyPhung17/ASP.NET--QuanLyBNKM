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
    public class BENHNHANsController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();

        // GET: BENHNHANs
        public ActionResult Index()
        {
            return View(db.BENHNHANs.ToList());
        }

        // GET: BENHNHANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENHNHAN bENHNHAN = db.BENHNHANs.Find(id);
            if (bENHNHAN == null)
            {
                return HttpNotFound();
            }
            return View(bENHNHAN);
        }

        // GET: BENHNHANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BENHNHANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MABN,TENBN,NGAYSINHBN,DIACHIBN,GIOITINH,CMND,BHYT")] BENHNHAN bENHNHAN)
        {
            if (ModelState.IsValid)
            {
                db.BENHNHANs.Add(bENHNHAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bENHNHAN);
        }

        // GET: BENHNHANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENHNHAN bENHNHAN = db.BENHNHANs.Find(id);
            if (bENHNHAN == null)
            {
                return HttpNotFound();
            }
            return View(bENHNHAN);
        }

        // POST: BENHNHANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MABN,TENBN,NGAYSINHBN,DIACHIBN,GIOITINH,CMND,BHYT")] BENHNHAN bENHNHAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bENHNHAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bENHNHAN);
        }

        // GET: BENHNHANs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENHNHAN bENHNHAN = db.BENHNHANs.Find(id);
            if (bENHNHAN == null)
            {
                return HttpNotFound();
            }
            return View(bENHNHAN);
        }

        // POST: BENHNHANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BENHNHAN bENHNHAN = db.BENHNHANs.Find(id);
            db.BENHNHANs.Remove(bENHNHAN);
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
