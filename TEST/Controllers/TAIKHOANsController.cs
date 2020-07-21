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
    public class TAIKHOANsController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();

        // GET: TAIKHOANs
        public ActionResult Index()
        {
            var tAIKHOANs = db.TAIKHOANs.Include(t => t.BACSI);
            return View(tAIKHOANs.ToList());
        }
        [HttpPost]
        public ActionResult Index(String tenBS)
        {
            var tAIKHOANs = db.BACSIs.Where(abc => abc.TENBS.Contains(tenBS));
            return View(tAIKHOANs.ToList());
        }

        // GET: TAIKHOANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // GET: TAIKHOANs/Create
        public ActionResult Create()
        {
            ViewBag.MABS = new SelectList(db.BACSIs, "MABS", "TENBS");
            return View();
        }

        // POST: TAIKHOANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATK,MABS,ADMIN,TENDN,MATKHAU")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.TAIKHOANs.Add(tAIKHOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MABS = new SelectList(db.BACSIs, "MABS", "TENBS", tAIKHOAN.MABS);
            return View(tAIKHOAN);
        }

        // GET: TAIKHOANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MABS = new SelectList(db.BACSIs, "MABS", "TENBS", tAIKHOAN.MABS);
            return View(tAIKHOAN);
        }

        // POST: TAIKHOANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATK,MABS,ADMIN,TENDN,MATKHAU")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAIKHOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MABS = new SelectList(db.BACSIs, "MABS", "TENBS", tAIKHOAN.MABS);
            return View(tAIKHOAN);
        }

        // GET: TAIKHOANs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: TAIKHOANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            db.TAIKHOANs.Remove(tAIKHOAN);
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
